using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db) 
        { 

        }
       public async Task<IEnumerable<ProductModel>> GetProductWithCategory()
        {
            var data = await (from p in _db.Products
                        join c in _db.Categories
                        on p.CategoryId equals c.CategoryId
                        select new
                        {
                            p.ProductId,
                            p.Name,
                            p.UnitPrice,
                            p.Description,
                            Category = c.Name
                        }).ToListAsync();
            IList<ProductModel> products = new List<ProductModel>();
            foreach (var item in data)
            {
                products.Add(new ProductModel
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    UnitPrice = item.UnitPrice,
                    Description = item.Description,
                    Category = item.Category
                });
            }
            return products;
        }
    }
}
