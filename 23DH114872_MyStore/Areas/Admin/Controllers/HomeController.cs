using _23DH114872_MyStore.Models;
using _23DH114872_MyStore.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23DH114872_MyStore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Admin/Home
        public ActionResult Index(string searchTerm, int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Tìm kiếm sản phẩm trên từ khóa
            if(!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where( p => p.ProductName.Contains(searchTerm) ||
                p.ProductDescription1.Contains(searchTerm) ||
                p.Category.CategoryName.Contains(searchTerm));
            }
            //Đoạn code liên quan tới phân trang 
            //Lấy số trang hiện tại ( mặc đinh là trang 1 nếu không có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = 6;
            //Lấy top 10 sản phẩm bán chạy nhất
            model.FeaturedProducts = products.OrderByDescending( p => p.OrderDetails.Count()).Take(10).ToList();

            //Lấy 20 sản phẩm bán ê nhất và phân trang
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);
            return View();
        }
    }
}