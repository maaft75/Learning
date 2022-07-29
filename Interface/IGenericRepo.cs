using System.Linq.Expressions;

namespace bookApi.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        void Save();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(int Id);
        List<T> GetAll(Expression<Func<T, bool>> expression);
    }
}