using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Authentication;
using TravelOoty.Application.Models.Profile;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        { 
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPut("UpdateProfile")]
        public async Task<ActionResult<RegistrationResponse>> UpdateProfileAsync(ProfileRequest request)
        {
            return Ok(await _authenticationService.UpdateProfileAsync(request));
        }

        [HttpPost("ResetPassword")]

        public async Task<ActionResult<ResetPasswordResponse>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _authenticationService.ResetPasswordAsync(request));
        }

        [HttpPost("ForgotPassword")]

        public async Task<ActionResult<ForgotPasswordResponse>> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            return Ok(await _authenticationService.ForgotPasswordAsync(request));
        }
        [HttpPost("ForgotResetPassword")]
        public async Task<ActionResult<ForgotResetPasswordResponse>> ForgotResetPasswordAsync(ForgotResetPasswordRequest request)
        {
            return Ok(await _authenticationService.ForgotPasswordSubmit(request));
        }
        [HttpGet("GetUserByIdAysnc")]
        
        public async Task<ActionResult<UserResponse>> GetUserByIdAysnc(string id)
        {
            return Ok(await _authenticationService.GetUserById(id));
        }
    
        [Route("UploadProfileImage")]
        [HttpPost]
        public async Task<ActionResult<ImageResponse>> UploadProfilePhotoAsync([FromForm] ImageRequest file)
        {
            return Ok(await _authenticationService.UploadProfilePhotoAsync(file));
        }
        
    }
}
