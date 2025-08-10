using Book_Store.Entity;

namespace Book_Store.Model
{
    public class GetBookModel
    {
        public string Title { get; set; }
        // public string Author { get; set; }

        public string Description { get; set; }

        // public string Category { get; set; }
        public long Quantity { get; set; }
        public long AvulebalQuantity {  get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public string? UpdateBy { get; set; }
        public DateTime? LastUpdated { get; set; }

        public List<string> BookCategory { get; set; }
        public string AutherName { get; set; }
    }
}
