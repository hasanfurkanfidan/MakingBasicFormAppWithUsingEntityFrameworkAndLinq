using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Products> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add(Products products)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(products);
                context.SaveChanges();

            }
        }

        public void Update(Products products)
        {
            using (ETradeContext context =new ETradeContext())
            {
                var entity = context.Entry(products);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Products products)
        {
            using (ETradeContext context=new ETradeContext())
            {
                var entity = context.Entry(products);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Products> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.ToLower().Contains(key.ToLower())).ToList();

            }
        }
        

    }
}
