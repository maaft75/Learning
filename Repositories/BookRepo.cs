using bookApi.Data;
using bookApi.Models;

namespace bookApi.Repositories
{
    public class BookRepo : GenericSqlRepo<Book>
    {
        public BookRepo(DataContext context) : base(context)
        {
            
        }
    }
}