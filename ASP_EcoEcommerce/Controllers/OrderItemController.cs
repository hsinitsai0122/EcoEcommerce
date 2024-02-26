using ASP_EcoEcommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using BLL_EcoEcommerce;
using ASP_EcoEcommerce.Handlers;
using BLL = BLL_EcoEcommerce.Entities;
using BLL_EcoEcommerce.Entities;
using DAL_EcoEcommerce.Entities;
using System.Reflection;

namespace ASP_EcoEcommerce.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemRepository<BLL.OrderItem> _orderItemRepository;
        private readonly ICartRepository<BLL.Cart> _cartRepository;
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;

        public OrderItemController(IOrderItemRepository<BLL.OrderItem> orderItemRepository, ICartRepository<BLL.Cart> cartRepository, IProductRepository<BLL.Product> productRepository, IMediaRepository<BLL.Media> mediaRepository)
        {
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
        }

        // GET: OrderItemController
        public ActionResult Index()
        {
            IEnumerable<OrderItemListItemViewModel> model = _orderItemRepository.GetAll().Select(d => d.ToListItem());
 
            ViewBag.ProductName = new Dictionary<int, string>();
            ViewBag.MediaUrl = new Dictionary<int, string>();

            foreach (var item in model)
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
               

                var media = _mediaRepository.GetSingleImageForProduct(item.Id_Product); // Use item.Id_Product instead of product.Id_Product
                if (media != null)
                {
                    ViewBag.MediaUrl[item.Id_Product] = media.ImgUrl;
                }
                else
                {
                    ViewBag.MediaUrl[item.Id_Product] = "placeholderImageIndex.png";
                }
            }

            return View(model);
        }

        // GET: OrderItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItemController/Create
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

        // GET: OrderItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderItemController/Edit/5
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

        // GET: OrderItemController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderItemDeleteForm model = _orderItemRepository.GetById(id).ToDelete();
            if (model is null) throw new ArgumentOutOfRangeException(nameof(id), "Order Item not found");
            return View(model);
        }

        // POST: OrderItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderItemDeleteForm form)
        {
            try
            {
                _orderItemRepository.Delete(id);
                return RedirectToAction("Details", "Cart", new { id = form.Id_Cart });
            }
            catch
            {
                return View(form);
            }
        }

    }
}
