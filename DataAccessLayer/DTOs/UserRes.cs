namespace DataAccessLayer.DTOs
{
    public class UserRes
    {
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string CitizenId { get; set; }
        public DateOnly DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsMale { get; set; }
    }
}
