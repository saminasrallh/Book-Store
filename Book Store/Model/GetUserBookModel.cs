namespace Book_Store.Model
{
    public class GetUserBookModel
    {
        public DateTime RentalTime { get; set; }
        public DateTime deadline { get; set; }
        public string UserName  { get; set; } 
        public string BookName   { get; set; }
        public DateTime? ReturnTime { get; set; }

    }
}
