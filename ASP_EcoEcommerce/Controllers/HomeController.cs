using ASP_EcoEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using System.Diagnostics;
using BLL = BLL_EcoEcommerce.Entities;
using ASP_EcoEcommerce.Handlers;


namespace ASP_EcoEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository<BLL.Product> productRepository, IMediaRepository<BLL.Media> mediaRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
        }

        public IActionResult Index()
        {
            return View();
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
