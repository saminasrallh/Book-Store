using Book_Store.Entity;

namespace Book_Store.Model
{
    public class GetUserModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string phoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
    }
}
