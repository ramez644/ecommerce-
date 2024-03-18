namespace Oseas.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string CustName { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }

        public Boolean Statue { get; set; }

        public ICollection<Products> Productss { get; set; }


    }
}
