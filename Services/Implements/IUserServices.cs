using BusinessObject.Models;
using DataAccessLayer.DTOs;

namespace Services.Implements
{
    public interface IUserServices
    {
        List<User> GetAllUser();
        UserRes GetUserById(int id);
        void UpdatePassword(int id, string oldpass, string newpass, string confirmpass);
        UserRes UpdateUserInfo(UserUpdateReq user, int id);
        void DeleteUser(int id);
    }
}
