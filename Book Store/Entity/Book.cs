using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Entity
{
    public class Book

    {
        public int Id { get; set; }
        public string Title { get; set; }
        // public string Author { get; set; }

        public string Description { get; set; }

        // public string Category { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public string? UpdateBy { get; set; }
        public DateTime? LastUpdated { get; set; }

        public List<Category> BookCategory { get; set; }
        public int? AutherId { get; set; }
        public Auther Auther { get; set; }

        public List<UserBook> UserBook { get; set; }

        public long AvulebelQuantity {  get; set; } 
        // public List <Users> User { get; set; }

        //  [NotMapped]
        // public long AvailableBookCount
        //  {
        // get
        // {
        //  return Quantity - UserBook.Where(x => x.ReturnTime == null).LongCount();


        //  }
        //}



    }
}
