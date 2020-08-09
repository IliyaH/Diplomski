using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Models
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public BaseRepository() { }
        public void Delete(object id)
        {
            using (var db = new BazaDiplomskiEntities())
            {
               DbSet<TEntity> dbSet = db.Set<TEntity>();
               TEntity entityToDelete = db.Set<TEntity>().Find(id);
               db.Entry(entityToDelete).State = EntityState.Deleted;
               db.SaveChanges();
            }
        }

        public TEntity FindByID(object id)
        {
            using (var db = new BazaDiplomskiEntities()) 
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetList()
        {
            using (var db = new BazaDiplomskiEntities())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var db = new BazaDiplomskiEntities())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            using (var db = new BazaDiplomskiEntities())
            {
                db.Set<TEntity>().Attach(entityToUpdate);
                db.Entry(entityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}