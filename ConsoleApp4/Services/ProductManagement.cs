using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public class ProductManagement
    {
        private CrmDbContext db;

        public ProductManagement(CrmDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public Product CreateProduct(ProductOption prod)
        {
            Product product = new Product
            {
                Name = prod.Name,
                Price = prod.Price,
                Quantity = prod.Quantity,

            };


            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        internal Product FindProduct(int v)
        {
            throw new NotImplementedException();
        }

        public Product FindProductById(int id)
        {

            Product product = db.Products.Find(id);
            return product;
        }

        public Product Update(ProductOption prod, int productId)
        {

            Product product = db.Products.Find(productId);

            if (prod.Name != null)
                product.Name = prod.Name;
            if (prod.Price != null)
                product.Price = prod.Price;
            if (prod.Quantity != null)
                product.Quantity = prod.Quantity;

            db.SaveChanges();
            return product;
        }

        public bool DeleteProductById(int id)
        {

            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            return false;

        }


    }
}
