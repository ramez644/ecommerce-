using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oseas.Helper;
using Oseas.Models;
using Oseas.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Oseas.Controllers
{
    public class ProductController : Controller
    {

        IproductReopsitory productRepo;
        private readonly IWebHostEnvironment webHostEnvironment;


        public ProductController(IproductReopsitory productRepos, IWebHostEnvironment webHostEnvironment)
        {
            productRepo = productRepos;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            return View(productRepo.GetProducts());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(Products newProd)
        {
            if (ModelState.IsValid)
            {




                //if (newProd.ImageUpload != null)
                //{
                //    //string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imageprod");

                ////string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "imageprod");
                //string imageName = Guid.NewGuid().ToString() + "_" + newProd.ImageUpload.FileName;
                //string filePath = Path.Combine(FolderPath, imageName);
                //FileStream fs = new FileStream(filePath, FileMode.Create);
                //await newProd.ImageUpload.CopyToAsync(fs);

                //fs.Close();
                //newProd.Image = imageName;
                if (newProd.ImageUpload != null)
                {
                    newProd.Image = DocumentSetting.UploadFile(newProd.ImageUpload, "imageprod");
                }


                try
                {
                    productRepo.Insert(newProd);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(String.Empty, ex.Message.ToString());

                }

            }
        




    
          
            return View("Add", newProd);


        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            Products Prodmodel=productRepo.GetById(id);
            return View(Prodmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id,Products newProduct)
        {
            if (newProduct.ProductName!=null)

            {
                if (newProduct.ImageUpload != null)
                {
                    newProduct.Image = DocumentSetting.UploadFile(newProduct.ImageUpload, "imageprod");
                }
                Products oldProd=productRepo.GetById(id);
                productRepo.Update(id, newProduct);

                if (oldProd!=null)
                {
                    oldProd.ProductName = newProduct.ProductName;
                    oldProd.ProductKind = newProduct.ProductKind;
                    oldProd.Price = newProduct.Price;
                    oldProd.Image = newProduct.Image;
                    
                    return RedirectToAction("Index");


                }



            }
            return View("Edit", newProduct);

         
        }




    }
}
