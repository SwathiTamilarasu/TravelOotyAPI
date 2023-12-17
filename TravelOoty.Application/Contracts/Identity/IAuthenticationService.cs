using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Models.Authentication;
using TravelOoty.Application.Models.Profile;

namespace TravelOoty.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<ProfileResponse> UpdateProfileAsync(ProfileRequest request);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<ForgotResetPasswordResponse> ForgotPasswordSubmit(ForgotResetPasswordRequest request);
        Task<UserResponse> GetUserById(string Id);
        Task<ImageResponse> UploadProfilePhotoAsync(ImageRequest imageRequest);
        Task<Unit> DeleteUser(string Id);
    }
}
 