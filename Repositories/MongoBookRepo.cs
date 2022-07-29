using bookApi.Data;
using bookApi.Models;

namespace bookApi.Repositories
{
    public class MongoBookRepo : GenericMongoRepo<mBook>
    {
        public MongoBookRepo(MongoContext context, string name = "Book") : base(name, context) 
        {
            
        }
    }
}