using ASP_EcoEcommerce.Handlers;
using ASP_EcoEcommerce.Models;
using BLL_EcoEcommerce.Entities;
using DAL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using BLL = BLL_EcoEcommerce.Entities;


namespace ASP_EcoEcommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;
        private readonly IOrderItemRepository<BLL.OrderItem> _orderItemRepository;
        private readonly ICartRepository<BLL.Cart> _cartRepository;
        //private readonly CartSessionManager _cartSessionManager;

        public ProductController(IProductRepository<BLL.Product> productRepository, IMediaRepository<BLL.Media> mediaRepository, IOrderItemRepository<BLL.OrderItem> orderItemRepository, ICartRepository<BLL.Cart> cartRepository)
        {
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            //_cartSessionManager = cartSessionManager;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.GetAll().Select(d => d.ToListItem());

            
            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {
              
                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {
                    
                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {
                   
                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }


        public IActionResult AllProducts()
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.GetAll().Select(d => d.ToListItem());


            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {

                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {

                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {

                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }


        public IActionResult FilterByPopularity()
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.FilterByPopularity().Select(d => d.ToListItem());


            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {

                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {

                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {

                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }

        public IActionResult FilterByCategory(string id)
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.FilterByCateg(id).Select(d => d.ToListItem());

            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {

                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {

                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {

                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }

        public IActionResult FilterByEcoScore(string id)
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.FilterByEcoScore(id).Select(d => d.ToListItem());

            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {

                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {

                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {

                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }

        public IActionResult FilterByName(string searchTerm)
        {
            IEnumerable<ProductListItemViewModel> model = _productRepository.FilterByName(searchTerm).Select(d => d.ToListItem());

            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var product in model)
            {

                var media = _mediaRepository.GetSingleImageForProduct(product.Id_Product);
                if (media != null)
                {

                    ViewBag.MediaUrl[product.Id_Product] = media.ImgUrl;
                }
                else
                {

                    ViewBag.MediaUrl[product.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            return View(model);
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductDetailsViewModel model = _productRepository.GetById(id).ToDetails();
            var medias = _mediaRepository.GetMediaForProduct(id);
            var mediaUrls = medias.Select(d => d.ImgUrl).ToList();

            ViewBag.MediaUrls = mediaUrls;
            return View(model);

        }

        [HttpPost]
        //public IActionResult AddToCart(int id, int quantity)
        //{
        //    var product = _productRepository.GetById(id);

        //    //if (product == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var cart = HttpContext.Session.Get<BLL.Cart>("Cart");

        //    //if (cart == null)
        //    //{
        //    //    cart = new BLL.Cart();
        //    //}

        //    //var orderItem = new BLL.OrderItem
        //    //(

        //    //    id,
        //    //    quantity
        //    //);

        //    //cart.AddToCart(orderItem); 

        //    //HttpContext.Session.Set("Cart", cart);
        //    _cartSessionManager.AddToCart(product, quantity);


        //    return RedirectToAction("Index", "Cart");
        //}



        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
