using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oseas.Validation;

namespace Oseas.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string ProductName { get; set; }


        public float Price { get; set; }
        public string Description { get; set; }


        public  string ProductKind { get; set; }

        public string Image { get; set; }
        //public int ?ShopingCardId { get; set; }


        //public ShopingCard ?ShopingCard { get; set; }

        [NotMapped]
        //[FileExtension]
        public IFormFile ImageUpload { get; set; }

        public List<CardDetail> cardDetails { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Supplier>? suppliers { get; set; }


    }
}
