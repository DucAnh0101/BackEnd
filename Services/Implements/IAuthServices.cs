using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace Services.Implements
{
    public interface IAuthServices
    {
        Task ResetPasswordAsync(ResetPassReq request);
        string Login(LoginRequest request);
    }
}
