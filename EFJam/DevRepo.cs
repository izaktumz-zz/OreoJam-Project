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
        public async Task<List<T>> Get_Items<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await db.Set<T>().Where(predicate).ToListAsync();
        }
        public IQueryable<T> Query<T>() where T : class
        {
            return db.Set<T>();
        }
        public T GetItem<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().FirstOrDefault(predicate);      
        }
        public async Task<T> Get_Item<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await db.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public void UpdateItem<T>(T data) where T:class
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async Task Update_Item<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public void UpdateItems<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public async Task Update_Items<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Modified;
            }
           await db.SaveChangesAsync();
        }
        public void DeleteItem<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
        }
        public async Task Delete_Item<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public void DeleteItems<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }
        public async Task Delete_Items<T>(List<T> data) where T : class
        {
            foreach (var item in data)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
          await  db.SaveChangesAsync();
        }
        public T AddItem<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Added;
            db.SaveChanges();
            return db.Set<T>().LastOrDefault();
        }

        public async Task<T> Add_Item<T>(T data) where T : class
        {
            db.Entry(data).State = EntityState.Added;
            await db.SaveChangesAsync();
            return  db.Set<T>().LastOrDefault();
        }

        public void AddItems<T>(List<T> data) where T : class
        {
            db.Set<T>().AddRange(data);
            db.SaveChanges();
        }

        public async Task Add_Items<T>(List<T> data) where T : class
        {
            db.Set<T>().AddRange(data);
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
