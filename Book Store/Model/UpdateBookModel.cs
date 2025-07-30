namespace Book_Store.Model
{
    public class UpdateBookModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public long Quantity { get; set; }
        public double Price { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
