using EcomProj.DataAccess.Data;
using EcomProj.DataAccess.Repository.IRepository;
using EcomProj.Model;
using EcomProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcomProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _db = db;   
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<Product> productList = _db.Products;
            return View(productList);

        }
        public IActionResult Details(int productId)
        {

            ShoppingCart cartObj = new()
            {
                Count = 1,
                ProductId = productId,
                Product = _db.Products.FirstOrDefault(u => u.Id == productId)

            };
            return View(cartObj);
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