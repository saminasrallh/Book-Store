namespace Book_Store.Entity
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedTime { get; set; }
    }
}
