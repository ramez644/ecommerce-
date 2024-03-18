using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oseas.Migrations;
using Oseas.Models;
using System.Net;

namespace Oseas.Repository
{
    public class ShopingCardRepository : IShopingCardRepository
    {
        Entity context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;//identity user

        public ShopingCardRepository(Entity db, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            context = db;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }


        public void AddItem(ShopingCard cart)
        {
            context.ShopingCards.Add(cart);
              context.SaveChanges();
        }
        //public void AddToCart(int prodId,string userId/*, int qty*/)
        //{

        //    //string userId = GetUserId();
        //    using var transaction = context.Database.BeginTransaction();
        //    try
        //    {
        //        if (string.IsNullOrEmpty(userId))
        //            throw new Exception("user is not logged-in");
        //        var cart =  GetCart(userId);
        //        //if (cart is null)
        //        //{
        //        //    cart = new ShopingCard
        //        //    {
        //        //        UserId = userId
        //        //    };
        //        //    context.ShopingCards.Add(cart);
        //        //}
        //        context.SaveChanges();
        //        // cart detail section
        //        var cartItem = context.CardDetails
        //                            .FirstOrDefault(a => a.ShopingCardId == cart.Id&& a.ProductsId == prodId);

        //        if (cartItem is not null)
        //        {

        //            cartItem.Quantity +=1;

        //        }
        //        else
        //        {
        //            var prod = context.Productss.Find(prodId);
        //            cartItem = new CardDetail
        //            {
        //                ProductsId = prodId,
        //                Id = cart.Id,
        //                //Quantity = qty,
        //                UnitPrice = prod.Price

        //            };
        //            context.CardDetails.Add(cartItem);
        //        }
        //        context.SaveChanges();
        //        transaction.Commit();

        //    }

        //    catch (Exception ex)
        //    {

        //    }





        //}



        //public async Task<int> GetCartItemCount(string userId = "")
        //{
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        userId = GetUserId();
        //    }




        //var data = await (from cart in context.ShopingCards
        //                  join cartDetail in context.ShopingCards
        //                  on cart.Id equals cartDetail.ShoppingCartId
        //                  where cart.UserId == userId // updated line
        //                  select new { cartDetail.Id }
        //            ).ToListAsync();}




        public async Task<ShopingCard> GetCart(string userId)
        {
            var cart = context.ShopingCards.FirstOrDefault(a => a.UserId == userId);
            return cart;

        }


        public string GetUserId()
        {
            var principal = httpContextAccessor.HttpContext.User;
            string userId = userManager.GetUserId(principal);
            return userId;
        }
        public  List<ShopingCard> GetAll()
        {
          return context.ShopingCards.ToList();
           
                
        }
        public async Task<ShopingCard> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");
            var shoppingCart = await context.ShopingCards
                                  //.Include(a => a.cardDetails)
                                   .Include(a => a.Product)
                                  .Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return shoppingCart;

        }



     
    }
}
