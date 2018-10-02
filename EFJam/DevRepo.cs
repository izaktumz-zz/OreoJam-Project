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
        public void Update<T>(T data,string status) where T:class
        {
            switch (status)
            {
                case "d":
                    db.Entry(data).State = EntityState.Deleted;
                    break;
                case "m":
                    db.Entry(data).State = EntityState.Modified;
                    break;
                default:
                    break;
            }

        }
        public void UpdateChanges<T>(List<T> data, string status) where T:class
        {
            switch (status)
            {

                case "d":
                    foreach (var item in data)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }  
                    break;
                case "m":
                    foreach (var item in data)
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }     
                    break;
                default:
                    break;
            }
        }  
        public void Add<TItem1>(TItem1 t1) where TItem1:class
        {
            db.Set<TItem1>().Add(t1);
        }
        public void Add<TItem1, TItem2>(TItem1 t1,TItem2 t2) where TItem1:class where TItem2:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
        }
        public void Add<TItem1, TItem2,TItem3>(TItem1 t1, TItem2 t2, TItem3 t3) where TItem1 : class where TItem2:class where TItem3:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
            db.Set<TItem3>().Add(t3);
        }
        public void Add<TItem1, TItem2, TItem3,TItem4>(TItem1 t1, TItem2 t2, TItem3 t3,TItem4 t4) where TItem1 : class where TItem2 : class where TItem3 : class where TItem4:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
            db.Set<TItem3>().Add(t3);
            db.Set<TItem4>().Add(t4);
        }
        public void Add<TItem1, TItem2, TItem3, TItem4,TItem5>(TItem1 t1, TItem2 t2, TItem3 t3,TItem4 t4,TItem5 t5) where TItem1 : class where TItem2 : class where TItem3 : class where TItem4:class where TItem5:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
            db.Set<TItem3>().Add(t3);
            db.Set<TItem4>().Add(t4);
            db.Set<TItem5>().Add(t5);
        }
        public void Add<TItem1, TItem2, TItem3, TItem4, TItem5,TItem6>(TItem1 t1, TItem2 t2, TItem3 t3, TItem4 t4, TItem5 t5, TItem6 t6) where TItem1 : class where TItem2 : class where TItem3 :class where TItem4 : class where TItem5 : class  where TItem6:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
            db.Set<TItem3>().Add(t3);
            db.Set<TItem4>().Add(t4);
            db.Set<TItem5>().Add(t5);
            db.Set<TItem6>().Add(t6);
        }
        public void Add<TItem1, TItem2, TItem3, TItem4, TItem5, TItem6,TITem7>(TItem1 t1, TItem2 t2, TItem3 t3, TItem4 t4, TItem5 t5, TItem6 t6,TITem7 t7) where TItem1 : class where TItem2 : class where TItem3 : class where TItem4 : class where TItem5 : class where TItem6 : class where TITem7:class
        {
            db.Set<TItem1>().Add(t1);
            db.Set<TItem2>().Add(t2);
            db.Set<TItem3>().Add(t3);
            db.Set<TItem4>().Add(t4);
            db.Set<TItem5>().Add(t5);
            db.Set<TItem6>().Add(t6);
            db.Set<TITem7>().Add(t7);
        }
        public void CommitChanges()
        {
            db.SaveChanges();
        }
        public async Task CommitChangesAsync()
        {
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
