namespace Book_Store.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string phoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Roles>Roles { get; set; }

      //  public List <Book>books { get; set; }
        public List <UserBook> UserBooks { get; set; }

     
    }
}
