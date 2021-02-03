using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet: EF eklemek için kullanıldı.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using: IDisposible pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);//veri kaynağıyla ilişkilendirildi.
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //ekleme olarak durumunu güncelle
                context.SaveChanges();//Ekle
            }
        }
    }
}
