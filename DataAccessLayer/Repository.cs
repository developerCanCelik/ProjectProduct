using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; //object bizim parametrelerimizi karşılayacak

        public Repository()
        {
            _object = c.Set<T>();
        }       

        public int Delete(T p)
        {
            var deleteenttity = c.Entry(p);
            deleteenttity.State = EntityState.Deleted;
            //_object.Remove(p);
            return c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            var addentitiy = c.Entry(p);
            addentitiy.State = EntityState.Added;
            //_object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            var updateentity = c.Entry(p);
            updateentity.State = EntityState.Modified;
            return c.SaveChanges();
        }
    }
}
