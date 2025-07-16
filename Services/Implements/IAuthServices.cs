using DataAccessLayer.DTOs.request;

namespace Services.Implements
{
    public interface IAuthServices
    {
        Task ResetPasswordAsync(ResetPassReq request);
        string Login(LoginRequest request);
    }
}
