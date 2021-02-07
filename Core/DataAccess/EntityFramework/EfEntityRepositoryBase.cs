using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //entityframework kullanarak bir repository base'i oluştur demek
    //buna da entityframework ekledik.
    //NorthwindContext olan yerlere TContext yazdık, Product olan yerlere de TEntity yazdık.
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using: IDisposible pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }
    }
}
