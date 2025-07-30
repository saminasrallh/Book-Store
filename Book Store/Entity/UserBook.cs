namespace Book_Store.Entity
{
    public class UserBook
    {
        
        public int Id { get; set; }
        public DateTime RentalTime { get; set; }
        public DateTime deadline { get; set; }
        public DateTime? ReturnTime { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }


    }
}
