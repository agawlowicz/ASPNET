using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}
