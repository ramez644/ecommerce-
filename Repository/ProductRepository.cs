using Microsoft.AspNetCore.Hosting;
using Oseas.Models;

namespace Oseas.Repository
{
    public class ProductRepository : IproductReopsitory
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        Entity context; //=new Entity();

        public ProductRepository(Entity db)
        {
            context = db;


        }

      

        public void Delete(int id)
        {
            Products rem = GetById(id);
            context.Remove(rem);
            context.SaveChanges();


        }

        public Products GetById(int id)
        {
          Products prod= context.Productss.FirstOrDefault(p => p.Id == id);
            return prod;
            
        }

        public Products GetByKind(string kind)
        {
            throw new NotImplementedException();
        }

        //public Products GetByKind(string kind)
        //{
        //    Products prodk = context.Productss.FirstOrDefault(p => p.ProductKind == kind);
        //    return prodk;


        //}

        public List<Products> GetProducts()
         
        {
            return context.Productss.ToList();

        }

        public async void Insert(Products newprod)
        {
      
            context.Productss.Add(newprod);
            context.SaveChanges();

                         
        }

        public void Update(int id, Products newProduct)
        {
            Products oldProd = GetById(id);
            oldProd.ProductName = newProduct.ProductName;
            oldProd.ProductKind= newProduct.ProductKind;
            oldProd.Price = newProduct.Price;
            oldProd.Image=newProduct.Image;
            context.SaveChanges();


        }
    }
}
