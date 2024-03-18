using Oseas.Models;

namespace Oseas.Repository
{
    public interface IShopingCardRepository
    {
        void AddItem(ShopingCard cart);
        Task<ShopingCard> GetCart(string userId);
        List<ShopingCard> GetAll();
        Task<ShopingCard> GetUserCart();


        string GetUserId();

    }
}
