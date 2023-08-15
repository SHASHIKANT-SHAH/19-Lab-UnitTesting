using AspNetCoreUnitTesting.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Product = DAL.Entities.Product;

namespace AspNetCoreUnitTesting.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Category> _categoryRepo;
        IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo, IRepository<Category> categoryRepo) 
        { 
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var data = await _productRepo.GetProductWithCategory();
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await GetCategory();
            return View();
        }

        async Task<IEnumerable<Category>> GetCategory()
        {
            var data = await _categoryRepo.GetAll();
            return data;
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product model)
        {
            //Product product = new Product();
            try
            {
                ModelState.Remove("ProductId");
                if(ModelState.IsValid)
                {
                    //product.ProductId = model.ProductId;
                    //product.Name = model.Name;
                    //product.Description = model.Description;
                    //product.UnitPrice = model.UnitPrice;
                    //product.CategoryId = model.CategoryId;
                    _productRepo.Add(model);
                    _productRepo.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Categories =  await GetCategory();
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Categories = await GetCategory();
            Product model = await _productRepo.Find(id);
            //ProductModel model = new ProductModel();
            //if (data != null)
            //{
            //    model.ProductId = data.ProductId;
            //    model.Name = data.Name;
            //    model.Description = data.Description;
            //    model.UnitPrice = data.UnitPrice;
            //    model.CategoryId = data.CategoryId;
            //}
            return View("Create",model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(int id, Product model)
        {
            //Product product = new Product();
            try
            {
                if (ModelState.IsValid)
                {
                    //product.ProductId = model.ProductId;
                    //product.Name = model.Name;
                    //product.Description = model.Description;
                    //product.UnitPrice = model.UnitPrice;
                    //product.CategoryId = model.CategoryId;
                    _productRepo.Update(model);
                    _productRepo.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Categories = await GetCategory();
                return View("Create",model);

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
                _productRepo.Delete(id);
                _productRepo.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
