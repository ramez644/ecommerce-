namespace Oseas.Models
{
    public class Supplier
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Countrey { get; set; }


        public DateTime AriveDate { get; set; }

       public Boolean Statue { get; set; }


        public ICollection<Products> Productss { get; set; }




    }
}
