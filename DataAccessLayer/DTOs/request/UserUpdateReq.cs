namespace DataAccessLayer.DTOs.request
{
    public class UserUpdateReq
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateOnly DOB { get; set; }
        public bool IsMale { get; set; }
        public string CitizenId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
