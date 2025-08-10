using Book_Store.Entity;

namespace Book_Store.Model
{
    public class GetAutherModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDay { get; set; }
        
        public List<string> books {  get; set; }
    }
}
