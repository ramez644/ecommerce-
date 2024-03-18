namespace Oseas.Models
{
    public class CardDetail
    {
        public int Id { get; set; }

        public int ShopingCardId { get; set; }
        public int ProductsId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public Products products { get; set; }

        //public ShopingCard shopingCard { get; set; }

    }
}
