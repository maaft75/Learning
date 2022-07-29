using bookApi.Data;
using bookApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookApi.Repositories
{
    public class GenericSqlRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext _context;

        public GenericSqlRepo(DataContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.ChangeTracker.Clear();
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }
    }
}