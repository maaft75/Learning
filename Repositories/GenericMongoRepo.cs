using bookApi.Data;
using bookApi.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace bookApi.Repositories
{
    public class GenericMongoRepo<T> where T : class
    {
        private readonly string _name;
        private readonly MongoContext _context;

        public GenericMongoRepo(string name, MongoContext context)
        {
            _name = name;
            _context = context;
        }

        public void Create(T entity)
        {
            _context.GetCollection<T>(_name).InsertOne(entity);
        }

        public void Remove(Expression<Func<T, bool>> expression)
        {
            _context.GetCollection<T>(_name).DeleteOne(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.GetCollection<T>(_name).Find(expression).FirstOrDefault();
        }

        public void Update(Expression<Func<T, bool>> expression, T entity)
        {
            _context.GetCollection<T>(_name).ReplaceOne(expression, entity);
        }
    }
}