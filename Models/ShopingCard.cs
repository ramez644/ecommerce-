namespace Oseas.Models
{
    public class ShopingCard
    {

        public int id { get; set; }
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int ProductId { get; set; }
  
        public virtual Products Product{ get; set; }
        public virtual ApplicationUser User { get; set; }





    }
}
