using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs;
using Services.Implements;

namespace Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly MyDbContext _dbContext;
        public UserServices(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUser()
        {
            var user = _dbContext.Users.ToList();
            if (user == null) throw new Exception("No user registered to system!");
            return user;
        }

        public UserRes GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) throw new Exception("No User found!");
            if (user.IsDelete) throw new Exception("User has been banned");

            return new UserRes
            {
                UserName = user.UserName,
                CitizenId = user.CitizenId,
                DOB = user.DOB,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                IsMale = user.IsMale,
            };
        }

        public UserRes UpdateUserInfo(UserUpdateReq user, int id)
        {
            var u = _dbContext.Users
                .Where(u => u.IsDelete == false)
                .FirstOrDefault(x => x.Id == id);
            if (u == null) throw new Exception($"No User found with {id}!");

            u.UserName = user.UserName;
            u.CitizenId = user.CitizenId;
            u.DOB = user.DOB;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            u.IsMale = user.IsMale;

            _dbContext.Users.Update(u);
            _dbContext.SaveChanges();

            return new UserRes
            {
                UserName = u.UserName,
                CitizenId = u.CitizenId,
                DOB = u.DOB,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                RoleId = u.RoleId,
                IsMale = u.IsMale
            };
        }

        public void DeleteUser(int id)
        {
            var u = _dbContext.Users
                .Where(u => u.IsDelete == false)
                .FirstOrDefault(x => x.Id == id);
            if (u == null) throw new Exception($"No User found with {id}!");

            u.IsDelete = true;
            _dbContext.SaveChanges();
        }

        public void UpdatePassword(int id, string oldpass, string newpass, string confirmpass)
        {
            var u = _dbContext.Users
                .Where(u => u.IsDelete == false)
                .FirstOrDefault(x => x.Id == id);
            if (u == null) throw new Exception($"No User found with {id}!");

            if (oldpass != u.Password) throw new Exception("The old password is wrong!");

            if (newpass != confirmpass) throw new Exception("The new password is match!");

            u.Password = confirmpass;
            _dbContext.SaveChanges();
        }

    }
}
