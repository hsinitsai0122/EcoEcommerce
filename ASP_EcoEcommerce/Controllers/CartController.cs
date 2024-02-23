using ASP_EcoEcommerce.Handlers;
using BLL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository<BLL.Cart> _cartRepository;
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;
        private readonly IOrderItemRepository<BLL.OrderItem> _orderItemRepository;
        private readonly CartSessionManager _cartSessionManager;

        public CartController(ICartRepository<Cart> cartRepository, IProductRepository<Product> productRepository, IMediaRepository<Media> mediaRepository, IOrderItemRepository<OrderItem> orderItemRepository, CartSessionManager cartSessionManager)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
            _orderItemRepository = orderItemRepository;
            _cartSessionManager = cartSessionManager;
        }

        // GET: CartController1
        public ActionResult Index()
        {
            var cart = _cartSessionManager.Cart;
            return View(cart);
        }

        // GET: CartController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CartController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CartController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
