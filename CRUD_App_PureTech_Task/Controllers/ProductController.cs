using CRUD_App_PureTech_Task.Models;
using CRUD_App_PureTech_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_App_PureTech_Task.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices services;
        private  Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public ProductController(IProductServices services, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.services = services;
            this.env = env;
        }
        public ActionResult Index()
        {
            return View(services.GetAllProducts());
        }
        public ActionResult Details(int id)
        {
            var model = services.GetProductById(id);
            return View(model);
        }        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,IFormFile file)
        {
            try
            {
                using(var fs=new FileStream(env.WebRootPath+"\\images\\"+file.FileName,FileMode.Create,FileAccess.Write))
                {
                    file.CopyTo(fs);    
                }
                product.Prod_imageUrl = "~/images/"+file.FileName;
                int result = services.AddProduct(product);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var model = services.GetProductById(id);
            HttpContext.Session.SetString("oldImage", model.Prod_imageUrl);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product,IFormFile file)
        {
            try
            {
                string oldimage = HttpContext.Session.GetString("oldImage");
                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    product.Prod_imageUrl = "~/images/" + file.FileName;
                    string[] str = oldimage.Split('/');
                    string path = env.WebRootPath + "\\images\\" + (str[str.Length - 1]);
                    System.IO.File.Delete(path);
                }
                else
                {
                    product.Prod_imageUrl = oldimage;
                }
                int result = services.UpdateProduct(product);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();
                }
               
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var result = services.GetProductById(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = services.DeleteProduct(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
