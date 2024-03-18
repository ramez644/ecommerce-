using Oseas.Models;

namespace Oseas.Repository
   
{
    public class CustomerRepository : IcustomerRepository
    {



        Entity context;//= new Entity()
        public Guid Id { get; set; }
        public CustomerRepository()
        {
            Id = Guid.NewGuid();
        }



        public CustomerRepository(Entity db)
        {

            context = db;

        }




       

        //public List<Products> ShopingCard(int id)
        //{
        //    Customer customer=new Customer();
        //    customer.Id = id;

        //    return context.Productss.Where(e => e.Id == id).ToList();





        //}

        //List<Customer> IcustomerRepository.ShopingCard(int custId)
        //{
        //    throw new NotImplementedException();
        //}

        void IcustomerRepository.Add(Customer product)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
