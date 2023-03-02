using DISample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DISample.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ProductService _productService; nếu ko sử dụng interface
        private readonly IProductService _productService;
        public HomeController(IProductService productService) //nếu ko sử dụng interface thì () để trống
        {
            //_productService = new ProductService(); nếu ko sử dụng interface
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
    }
}
