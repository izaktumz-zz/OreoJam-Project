using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
        /// <summary>
        /// Returns a List Of Items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Lambda expression i.e. x=>x.Id==1 or x=>x.Name==""</param>
        /// <returns></returns>
        public List<T> GetItems<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().Where(predicate).ToList();     
        }
        /// <summary>
        /// Returns a single Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Lambda expression i.e. x=>x.Id==1 or x=>x.Name==""</param>
        /// <returns></returns>
        public T GetItem<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().FirstOrDefault(predicate);      
        }
        /// <summary>
        /// Adds many items.Batch Operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public void AddItems<T>(List<T> data) where T : class
        {
            db.Set<T>().AddRange(data);
            db.SaveChanges();
        }
        /// <summary>
        /// Adds a single item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public void AddItem<T>(T data) where T : class
        {
           db.Set<T>().Add(data);
           db.SaveChanges();
        }
        public void DeleteItem<T>(T data) where T : class
        {
             db.Entry(data).State = EntityState.Deleted;
             db.SaveChanges();
        }
        public void UpdateItem<T>(T data) where T : class
        {
           db.Entry(data).State = EntityState.Modified;
           db.SaveChanges();
        }
        #endregion
    }
}
