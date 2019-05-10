using System.Data.Entity;
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb() : base("DefaultConnection")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}