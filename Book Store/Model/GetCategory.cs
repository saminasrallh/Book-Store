using Book_Store.Entity;

namespace Book_Store.Model
{
    public class GetCategory
    {
        public string Name { get; set; }
        public List<string> Books { get; set; }
    }
}
