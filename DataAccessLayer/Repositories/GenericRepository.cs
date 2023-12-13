using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            _dbSet= _context.Set<T>();
        }

        public void Delete(T t)
        {
            _context.Remove(t);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetList()
        {
           return _dbSet.ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultipleUpdate(List<T> list)
        {
           _context.UpdateRange(list);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
