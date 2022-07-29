using bookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Book> TBL_BOOKS {get; set;}
    }
}