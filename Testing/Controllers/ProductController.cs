using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//Product is the Controller and Index is the Method in that Controller

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/

        // Below corresponds with Index View we created for Product
        // Controller Index() method will return a View page of the same name (Index)
        // with the appropriate Model data (IEnumerable)
        //Controller facilitates handling a request and handing it to the correct view and model

        //Returns to us a View containing our Model data
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        // Pass in product as argument, serves as Model we will work within our ViewProduct.cshtml View
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
    }
}

//URl: Product/ViewProduct/id: Product is our Controller. ViewProduct is method located in ProductController.
//id is parameter passed into the ViewProductMethod
