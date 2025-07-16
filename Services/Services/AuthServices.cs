using BusinessObject;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Services.Implements;
using System.Net;
using System.Net.Mail;

namespace Services.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly MyDbContext dbContext;
        private readonly JwtTokenGenerator jwtTokenGenerator;

        public AuthServices(MyDbContext _dbContext, JwtTokenGenerator _jwtTokenGenerator)
        {
            dbContext = _dbContext;
            jwtTokenGenerator = _jwtTokenGenerator;
        }

        public async Task ResetPasswordAsync(ResetPassReq request)
        {
            var user = dbContext.Users.FirstOrDefault(u =>
                u.UserName == request.UserName &&
                u.PhoneNumber == request.PhoneNumber &&
                u.DOB == request.DOB &&
                u.CitizenId == request.CitizenId &&
                u.Email == request.Email);
            if (user == null)
            {
                throw new Exception("User is not exist or information is incorrect.");
            }
            var newPassword = GenerateRandomPassword();
            user.Password = newPassword;

            await dbContext.SaveChangesAsync();

            await SendEmailAsync(user.Email, "Reset password request", BuildResetPasswordEmailBody(user.UserName, newPassword));
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
            var rand = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var fromEmail = "bda2k3@gmail.com";
            var fromPassword = "buxi vval vqdf myls";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
        private string BuildResetPasswordEmailBody(string userName, string newPassword)
        {
            return $@"
                    <html>
                        <head>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                background-color: #f9f9f9;
                padding: 20px;
                color: #333;
            }}
            .container {{
                background-color: #fff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0 2px 5px rgba(0,0,0,0.1);
                max-width: 600px;
                margin: auto;
            }}
            .highlight {{
                color: #0056b3;
                font-weight: bold;
            }}
            .footer {{
                margin-top: 30px;
                font-size: 12px;
                color: #888;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h2>🔐 Yêu cầu đặt lại mật khẩu</h2>
            <p>Xin chào <span class='highlight'>{userName}</span>,</p>
            <p>Bạn hoặc ai đó đã yêu cầu đặt lại mật khẩu cho tài khoản của bạn.</p>
            <p>Mật khẩu mới của bạn là:</p>
            <p style='font-size: 18px; font-weight: bold; color: #d9534f;'>{newPassword}</p>
            <p>Hãy đăng nhập và đổi mật khẩu ngay để đảm bảo an toàn.</p>
            <p class='footer'>Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email này hoặc liên hệ bộ phận hỗ trợ.</p>
        </div>
    </body>
    </html>";
        }

        public string Login(LoginRequest request)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == request.Username && u.Password == request.Password);
            if (user == null) throw new Exception("Username or password is incorrect");
            if (user.IsDelete == true) throw new Exception("Your account is not be able to login.");

            var token = jwtTokenGenerator.GenerateToken(user.Id.ToString(), user.RoleId.ToString());

            return token;
        }

    }
}
