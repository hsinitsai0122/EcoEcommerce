using ASP_EcoEcommerce.Handlers;
using ASP_EcoEcommerce.Models;
using BLL_EcoEcommerce.Entities;
using DAL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using System.Collections;
using System.Collections.Generic;
using BLL = BLL_EcoEcommerce.Entities;

namespace ASP_EcoEcommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository<BLL.Cart> _cartRepository;
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;
        private readonly IOrderItemRepository<BLL.OrderItem> _orderItemRepository;
        //private readonly CartSessionManager _cartSessionManager;

        public CartController(ICartRepository<BLL.Cart> cartRepository, IProductRepository<BLL.Product> productRepository, IMediaRepository<BLL.Media> mediaRepository, IOrderItemRepository<BLL.OrderItem> orderItemRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
            _orderItemRepository = orderItemRepository;
         //   _cartSessionManager = cartSessionManager;
        }

        // GET: CartController1
        public ActionResult Index()
        {

            IEnumerable<CartListItemViewModel> model = _cartRepository.GetAll().Select(d => d.ToListItem());
  //          var cart = _cartRepository.GetById(id_Cart);
  

            //var orderItems = _orderItemRepository.GetAllItemsByIdCart(id_Cart);
 

            return View(model);
        }

        // GET: CartController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    // Retrieve the cart details including associated order items
        //    BLL.Cart cart = _cartRepository.GetById(id);
        //    CartDetailsViewModel model = cart.ToDetails();

        //    // Populate order items in the model directly from the Cart object
        //    model.OrderItems = cart.OrderItems.Select(d => d.ToListItem()).ToList();

        //    // Populate product names and media URLs
        //    ViewBag.ProductName = new Dictionary<int, string>();
        //    ViewBag.MediaUrl = new Dictionary<int, string>();

        //    foreach (var orderItem in cart.OrderItems)
        //    {
        //        var productName = _productRepository.GetProductNameById(orderItem.Id_Product);
        //        if (productName != null)
        //        {
        //            ViewBag.ProductName[orderItem.Id_Product] = productName;
        //        }
        //        else
        //        {
        //            ViewBag.ProductName[orderItem.Id_Product] = "Product Name Not Found";
        //        }

        //        var media = _mediaRepository.GetSingleImageForProduct(orderItem.Id_Product);
        //        if (media != null)
        //        {
        //            ViewBag.MediaUrl[orderItem.Id_Product] = media.ImgUrl;
        //        }
        //        else
        //        {
        //            ViewBag.MediaUrl[orderItem.Id_Product] = "~/assets/placeholderImageIndex.png";
        //        }
        //    }

        //    // Pass the cart ID to the view
        //    ViewBag.Id_Cart = id;

        //    return View(model);
        //}




        public ActionResult Details(int id)
        {

            CartDetailsViewModel model = _cartRepository.GetById(id).ToDetails();
            model.OrderItems = _orderItemRepository.GetAllItemsByIdCart(id).Select(d => d.ToListItem()).ToList();

            //List<string> productNames = new List<string>();
            ViewBag.ProductName = new Dictionary<int, string>();
            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var item in model.OrderItems)
            {
                var productName = _productRepository.GetProductNameById(item.Id_Product);
                if (productName != null)
                {
                    ViewBag.ProductName[item.Id_Product] = productName;
                }
                else
                {
                    ViewBag.ProductName[item.Id_Product] = "Product Name Not Found";
                }
                //if (productName != null)
                //{
                //productNames.Add(productName);
                //}
                //else
                //{
                //    productNames.Add("Product Name Not Found");
                //}

                var media = _mediaRepository.GetSingleImageForProduct(item.Id_Product); // Use item.Id_Product instead of product.Id_Product
                if (media != null)
                {
                    ViewBag.MediaUrl[item.Id_Product] = media.ImgUrl;
                }
                else
                {
                    ViewBag.MediaUrl[item.Id_Product] = "~/assets/placeholderImageIndex.png";
                }
            }

            ViewBag.Id_Cart = id;
            return View(model);
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
