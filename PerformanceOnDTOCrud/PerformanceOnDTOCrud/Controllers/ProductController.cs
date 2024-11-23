using PerformanceOnDTOCrud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PerformanceOnDTOCrud.DTOs;

namespace PerformanceOnDTOCrud.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        CrudwithDTOEntities2 db = new CrudwithDTOEntities2();

        public static Product Convert(ProductDTO p)
        {
            return new Product
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
             //   CategoryId = p.CategoryId

            };
        }
        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
               // CategoryId = p.CategoryId

            };
        }
        public static List<ProductDTO> Convert(List<Product> data)
        {
            var list = new List<ProductDTO>();
            foreach (var p in data)
            {
                list.Add(Convert(p));
            }
            return list;
        }

        public ActionResult List()
        {
            var data = db.Products.ToList();
            return View(Convert(data));
        }

    }
}