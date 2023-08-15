using AspNetCoreUnitTesting.Controllers;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Models;
using Moq;

namespace WebAppNUnitTestProject
{
    public class ProductControllerUnitTest
    {
        //Arrange
        ProductModel pm1;
        ProductModel pm2;
        ProductModel pm3;
        List<ProductModel> products;

        Category c1;
        Category c2;
        Category c3;
        List<Category> categories;


        Product p1;

        Mock<IProductRepository> mockProductRepo;
        Mock<IRepository<Category>> mockCategoryRepo;

        ProductController ctrl;

        [SetUp]
        public void Setup()
        {
            pm1 = new ProductModel() { ProductId = 1, Name = "IPhone", Description = "Description for IPhone", UnitPrice = 60000, Category = "Electronics", CategoryId = 1 };
            pm2 = new ProductModel() { ProductId = 2, Name = "Redmi", Description = "Description for Redmi", UnitPrice = 40000, Category = "Electronics", CategoryId = 2 };
            pm3 = new ProductModel() { ProductId = 3, Name = "UIPATH", Description = "Description for UIPATH", UnitPrice = 50000, Category = "Courses", CategoryId = 3 };

            products = new List<ProductModel>() { pm1, pm2 };

            c1 = new Category() { CategoryId = 1, Name = "Electronics" };
            c2 = new Category() { CategoryId = 2, Name = "Courses" };

            categories = new List<Category>() { c1, c2 };

            p1 = new Product() { ProductId = 4, Name = "UIPATH", Description = "Description for UIPATH", UnitPrice = 50000, CategoryId = 3 };


            mockProductRepo = new Mock<IProductRepository>();
            mockCategoryRepo = new Mock<IRepository<Category>>();

            ctrl = new ProductController(mockProductRepo.Object, mockCategoryRepo.Object);

        }

        [Test]
        public async Task TestIndexMethod()
        {
            //setup
            mockProductRepo.Setup(repo => repo.GetProductWithCategory()).ReturnsAsync(products);

            //Action
            var result = await ctrl.Index() as ViewResult;
            var model = result.Model as List<Models.ProductModel>;

            //Assert
            //Positive
            CollectionAssert.Contains(model, pm1);
            CollectionAssert.Contains(model, pm2);

            //Negative
            CollectionAssert.DoesNotContain(model, pm3);

        }

        [Test]
        public async Task TestCreateGetMethod()
        {
            //setup
            mockCategoryRepo.Setup(repo => repo.GetAll()).ReturnsAsync(categories);

            //Action
            var result = await ctrl.Create() as ViewResult;
            var viewData = result.ViewData["Categories"] as List<Category>;

            //Assert
            CollectionAssert.Contains(viewData, c1);
            CollectionAssert.Contains(viewData, c2);
        }

        [Test]
        public async Task TestCreatePostMethodSuccess()
        {

            //p1.ProductId = Convert.ToInt32('0');

            //setup
            //mockProductRepo.Setup(repo => repo.Add(p1)).Callback((Product model)=> {
            //ProductModel pm = new ProductModel { ProductId = model.ProductId, Name = model.Name, CategoryId =model.CategoryId };
            //});
            mockProductRepo.Setup(repo => repo.Add(p1));

            //action
            var result = await ctrl.Create(p1) as RedirectToActionResult;

            //Assert
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public async Task TestCreatePostMethodFailed()
        {

            p1.Name = null;

            //setup
            mockCategoryRepo.Setup(repo => repo.GetAll()).ReturnsAsync(categories);

            if (string.IsNullOrEmpty(p1.Name))
                ctrl.ModelState.AddModelError("Name", "Please Enter Name");

            //action
            var result = await ctrl.Create(p1) as ViewResult;
            var viewData = result.ViewData["Categories"] as List<Category>;


            //Assert
            CollectionAssert.Contains(viewData, c1);
            CollectionAssert.Contains(viewData, c2);
        }


        [Test]
        public async Task TestEditGetMethod()
        {
            int id = 4;
            //setup
            mockCategoryRepo.Setup(repo => repo.GetAll()).ReturnsAsync(categories);
            mockProductRepo.Setup(repo => repo.Find(id)).ReturnsAsync(p1);

            //Action
            var result = await ctrl.Edit(id) as ViewResult;
            var viewData = result.ViewData["Categories"] as List<Category>;
            var model = result.Model as Product;

            //Assert
            CollectionAssert.Contains(viewData, c1);
            CollectionAssert.Contains(viewData, c2);

            Assert.AreEqual("Create", result.ViewName);
            Assert.AreEqual(p1, model);
        }
        [Test]
        public async Task TestEditPostMethodSuccess()
        {
            int id = 4;
            //setup
            mockProductRepo.Setup(repo => repo.Update(p1));

            //Action
            var result = await ctrl.Edit(id, p1) as RedirectToActionResult;

            //Assert
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public async Task TestEditPostMethodFailed()
        {
            int id = 4;
            p1.Name = null;

            //setup
            mockCategoryRepo.Setup(repo => repo.GetAll()).ReturnsAsync(categories);

            if (string.IsNullOrEmpty(p1.Name))
                ctrl.ModelState.AddModelError("Name", "Please Enter Name");

            //action
            var result = await ctrl.Edit(id, p1) as ViewResult;
            var viewData = result.ViewData["Categories"] as List<Category>;

            //Assert
            Assert.AreEqual("Create", result.ViewName);

            CollectionAssert.Contains(viewData, c1);
            CollectionAssert.Contains(viewData, c2);


        }

        [Test]
        public void TestDeleteMethod()
        {
            int id = 1;
            //setup
            mockProductRepo.Setup(repo => repo.Delete(p1));

            //Action
            var result = ctrl.Delete(id) as RedirectToActionResult;

            //Assert
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}