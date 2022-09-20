namespace LibraryManagementSystem.Models
{
    public class UserAndBooks
    {
        public UserDetail User { get; set; }
        public List<BooksTransaction> books { get; set; }
    }
}
