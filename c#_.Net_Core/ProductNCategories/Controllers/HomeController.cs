using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductNCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace ProductNCategories.Controllers
{
    public class HomeController : Controller
    {
    private MyContext db;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = db.Products.ToList(); 
            return View("Products");
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product newProduct) {
            if (ModelState.IsValid)
            {
                db.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllProducts = db.Products.ToList(); 
            return Redirect("Products");
        }

        [HttpGet("catergories")]
        public IActionResult Catergories()
        {
            ViewBag.AllCatergories = db.Categories.ToList(); 
            return View("Catergories");
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                db.Add(newCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllCatergories = db.Categories.ToList(); 
            return Redirect("Catergories");
        }

        [HttpGet("Catergories/{categId}")]
        public IActionResult GetCategory(int categId)
        {
            ViewBag.getCategory = db.Categories.FirstOrDefault(c => c.CategoryId == categId);
            
            var prodWithCateg = db.Categories
            .Include(pc => pc.ProdCategories)
                .ThenInclude(prod => prod.Product)
                .FirstOrDefault(p => p.CategoryId == categId);

            ViewBag.productsWithCategories = prodWithCateg; 

            List<Product> AllProducts = db.Products.ToList();
            List<Product> SomeProducts = new List<Product>();

            //Manually added the product to categories in the dropdown menu  
            foreach(var prod in prodWithCateg.ProdCategories)
            {
                SomeProducts.Add(prod.Product);
            }

            ViewBag.OtherProducts = AllProducts.Except(SomeProducts).ToList();    
            return View("Category");
        }

        [HttpPost("AddProdToCat")]
        public IActionResult AddProdToCat(int categoryId, int productId)
        {
            Console.WriteLine(categoryId);
            Console.WriteLine(productId);
            ProdCategory prod = new ProdCategory();
            prod.CategoryId = categoryId;
            prod.ProductId = productId;
            
            db.Add(prod);
            db.SaveChanges();
            return Redirect("Catergories/" + categoryId);
        }

        [HttpGet("products/{prodId}")]
        public IActionResult GetProduct(int prodId)
        {
            ViewBag.getProduct = db.Products.FirstOrDefault(p => p.ProductId == prodId);
            
            var CategWithProd = db.Products
            .Include(pc => pc.ProdCategories)
                .ThenInclude(prod => prod.Category)
                .FirstOrDefault(p => p.ProductId == prodId);

            ViewBag.productsWithCategories = CategWithProd; 

            List<Category> AllCategories = db.Categories.ToList();
            List<Category> SomeCategories = new List<Category>();

            //Manually added the product to categories in the dropdown menu  
            foreach(var cat in CategWithProd.ProdCategories)
            {
                SomeCategories.Add(cat.Category);
            }

            ViewBag.OtherCategories = AllCategories.Except(SomeCategories).ToList();    
            return View("Product");
        }

        [HttpPost("AddCatToProd")]
        public IActionResult AddCatToProd(int categoryId, int productId)
        {
            Console.WriteLine(categoryId);
            Console.WriteLine(productId);
            ProdCategory cat = new ProdCategory();
            cat.CategoryId = categoryId;
            cat.ProductId = productId;
            
            db.Add(cat);
            db.SaveChanges();
            return Redirect("Products/" + productId);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
