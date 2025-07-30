namespace Book_Store.Entity
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Users> Users { get; set; }
    }
}
