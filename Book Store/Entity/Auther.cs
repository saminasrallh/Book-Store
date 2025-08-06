namespace Book_Store.Entity
{
    public class Auther:ISoftDelete
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDay { get; set; }
        public List <Book>books { get; set; }
        public bool IsDeleted { get; set ; }
        public DateTime? DeletedTime { get ; set ; }
    }
}
