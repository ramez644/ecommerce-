using Oseas.Models;

namespace Oseas.Repository
{
    public interface IcustomerRepository
    {
        //List<Products> ShopingCard(int  custId);

        List<Customer> GetAll();


        void Add(Customer Cust);




    }
}
