
namespace Book_Store.Entity
{
    public class Category:ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book>Books { get; set; }
        public bool IsDeleted { get ; set; }=false;
        public DateTime? DeletedTime { get; set; }
    }
}
