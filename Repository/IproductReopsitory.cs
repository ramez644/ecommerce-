using Oseas.Models;

namespace Oseas.Repository
{
    public interface IproductReopsitory
    {
        List<Products> GetProducts();

        Products GetById(int id);


        Products GetByKind(string kind);


        void Insert(Products newprod);

        void Update(int id, Products newProduct);


        void Delete(int id);







    }
}
