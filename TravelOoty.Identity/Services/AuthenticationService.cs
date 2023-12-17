using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Models.Authentication;
using TravelOoty.Application.Models.Mail;
using TravelOoty.Application.Models.Profile;
using TravelOoty.Identity.Models;

namespace TravelOoty.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;        
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailService;
        private readonly IBlobService _blobService;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IPropertyRepository _propertyRepository;
        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager, IEmailService emailService, IBlobService blobService, IPropertyRepository propertyRepository)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;            
            _signInManager = signInManager;
            _emailService = emailService;
            _blobService = blobService;
            _propertyRepository = propertyRepository;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            var allHotelCategory = await _propertyRepository.GetPropertyByUserId(user.Id);
            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = roles.Count != 0 ? roles.FirstOrDefault().Equals("Admin") : false,
                IsSuperAdmin = roles.Count != 0 ? roles.FirstOrDefault().Equals("Super Admin") : false,
                IsEmployee = user.isEmployee,
                IsPropertyOwner = allHotelCategory != null ?  true : false
            };

            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                isEmployee = request.isEmployee,
                AadharCardProof = request.AadharCardProof,
                Address=request.Address,
                DateOfBirth = request.DateOfBirth,
                Designation=   request.Designation,
                PhoneNumber= request.PhoneNumber,                
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                
                if (result.Succeeded)
                {                                        
                    return new RegistrationResponse() { UserId = user.Id,FirstName=user.FirstName,LastName=user.LastName };
                }
                else
                {
                    throw new Exception($"{result.Errors.FirstOrDefault().Description}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email } already exists.");
            }
        }
        public async Task<ProfileResponse> UpdateProfileAsync(ProfileRequest request)
        {
            var user= await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
                user.Id= request.UserId;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                user.Address = request.Address;
                user.AadharCardProof = request.AadharCardProof;
                user.DateOfBirth = request.DateOfBirth;
                user.Email = request.Email;
                user.isEmployee = request.isEmployee;
                user.Designation = request.Designation;
                

                var result=await _userManager.UpdateAsync(user);
              
                if (result.Succeeded)
                {
                    return new ProfileResponse() { Message = "Profile update completed" };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }         
        }
        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user,token,request.Password);
                if (result.Succeeded)
                {
                    return new ResetPasswordResponse() { Message = "Password updated" };
                }
                else
                {
                    throw new Exception($"{result.Errors.FirstOrDefault().Description}");
                }
            }
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                 var emailBody = $"https://travelooty.in/resetPassword?token={token}";
                var email = new Email() { To = request.Email, Body = emailBody, Subject = "Reset Password Link" };
                try
                {
                    await _emailService.SendPasswordEmail(email);
                   
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Mailing about event sending reset password link failed due to an error with the mail service: {ex.Message}");
                }
                 return new ForgotPasswordResponse() { Token = token };
            }

        }
        public async Task<ForgotResetPasswordResponse> ForgotPasswordSubmit(ForgotResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
                 var result = await _userManager.ResetPasswordAsync(user,request.Token,request.Password);
                if (result.Succeeded)
                {
                    return new ForgotResetPasswordResponse() { Message = "Password updated" };
                }
                else
                {
                    throw new Exception($"{result.Errors.FirstOrDefault().Description}");
                }
            }
        }

        public async Task<UserResponse> GetUserById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
               
              return new UserResponse() { UserId=user.Id,
                  FirstName = user.FirstName,LastName=user.LastName, Email=user.Email, UserName=user.UserName,
              Address=user.Address,PhoneNumber=user.PhoneNumber,
                  ImageName=user.ImageName,ImagePath=user.ImagePath,
                  isEmployee=user.isEmployee,DateOfBirth=user.DateOfBirth, Designation=user.Designation,
                  AadharCardProof=user.AadharCardProof
              };
               
            }
        }
        public async Task<Unit> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                throw new Exception($"User not found.");
            }
            else
            {

                var result = await _userManager.DeleteAsync(user);
                return Unit.Value;

            }
         }

        public async Task<ImageResponse> UploadProfilePhotoAsync(ImageRequest imageRequest)
        {

            var imageResponse = await _blobService.UploadImageToBlobAsync(imageRequest.UserId,imageRequest.File.OpenReadStream(),imageRequest.File.ContentType, imageRequest.FileName);
            if(imageResponse == null)
            {
                return new ImageResponse();
            }
            else
            {
                var user = await _userManager.FindByIdAsync(imageRequest.UserId);
                if (user == null)
                {
                    throw new Exception($"Something went wrong.");
                }
                else
                {
                    user.ImageName = imageResponse.ImageName;
                    user.ImagePath= imageResponse.ImageUri.ToString();
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return imageResponse;
                    }
                    else
                    {
                        throw new Exception($"{result.Errors}");
                    }

                }                
            }
           

        }
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
