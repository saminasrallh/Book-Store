namespace Book_Store.Model
{
    public class BookModelCreate
    {
        public string Title { get; set; }


        public int AutherId { get; set; }   
        public string Description { get; set; }
        public long Quantity { get; set; }

        public double Price { get; set; }

       
        public string CreatedBy { get; set; }
    }
}
