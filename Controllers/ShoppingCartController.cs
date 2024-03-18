using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oseas.Migrations;
using Oseas.Models;
using Oseas.Repository;
using System.Security.Claims;

namespace Oseas.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShopingCardRepository shopingCardRepository;


         


        public ShoppingCartController(IShopingCardRepository shopingCardRepository)
        {
            this.shopingCardRepository = shopingCardRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        //public async Task<IActionResult> AddItem(int prodId/*, int qty,*/ )
        //{
        //    var cartCount = await shopingCardRepository.AddToCart(prodId /*,qty*/);


        //    //return RedirectToAction("GetUserCart");
        //    //return Ok();
        //    return Json(new { success = true, message = "تمت إضافة المنتج إلى السلة" });




        //}
        //public IActionResult AddItem(int prodId)
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    shopingCardRepository.AddToCart(prodId, userId);
        //    return Json(new { success = true, message = "تمت إضافة المنتج إلى السلة" });



        //}


        public IActionResult AddToItem(int prodId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ShopingCard card = new ShopingCard()
            {
                ProductId = prodId,
               UserId = userId

            };

            shopingCardRepository.AddItem(card);
            return Json(new { success = true, message = "تمت إضافة المنتج إلى السلة" });
        }
        public IActionResult GettoAll()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(shopingCardRepository.GetAll().FirstOrDefault(s => s.UserId == userId));
        }

        public async Task<IActionResult> GetCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await shopingCardRepository.GetCart(userId);
            return View(cart);
        }
    }
}
 