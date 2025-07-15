using DataAccessLayer.DTOs;

namespace Services.Implements
{
    public interface IAuthServices
    {
        Task ResetPasswordAsync(ResetPassReq request);
    }
}
