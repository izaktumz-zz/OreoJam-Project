using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OreoJam
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Represents Name of The Table you want to query</typeparam>
    /// <typeparam name="TEntity">Represents Name of The Database.</typeparam>
    public class DevRepo<TEntity> where TEntity : DbContext, new()
    {
        #region Properties
        private readonly TEntity db;
        #endregion

        #region Constructor
        public DevRepo(TEntity _db)
        {
            db = _db;
        }
        #endregion

        #region Methods
        public List<T> GetItems<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().Where(predicate).ToList();     
        }
        public IQueryable<T> GetItemsIqueryable<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().Where(predicate);
        }
        public T GetItem<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().FirstOrDefault(predicate);      
        }
        public void UpdateItem<T>(T data) where T:class
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void UpdateItems<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public void DeleteItem<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
        }
        public void DeleteItems<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }
        public void AddItem<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
        }
        public void AddItems<T>(List<T> data) where T : class
        {
            db.Set<T>().AddRange(data);
            db.SaveChanges();
        }
        #endregion
    }
}
