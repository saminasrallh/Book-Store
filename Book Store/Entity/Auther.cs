namespace Book_Store.Entity
{
    public class Auther
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDay { get; set; }
        public List <Book>books { get; set; }

    

    }
}
