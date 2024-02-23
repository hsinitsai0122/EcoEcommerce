using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_EcoEcommerce.Repositories;
using Shared_EcoEcommerce.Repositories;
using BLL = BLL_EcoEcommerce.Entities;
using ASP_EcoEcommerce.Handlers;
using ASP_EcoEcommerce.Models;
using BLL_EcoEcommerce.Entities;
using System.Drawing.Imaging;

namespace ASP_EcoEcommerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository<BLL.Product> _productRepository;
        private readonly IMediaRepository<BLL.Media> _mediaRepository;

        public AdminController(IProductRepository<Product> productRepository, IMediaRepository<Media> mediaRepository)
        {
            _productRepository = productRepository;
            _mediaRepository = mediaRepository;
        }



        // GET: AdminController
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

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            ProductDetailsViewModel model = _productRepository.GetById(id).ToDetails();
            var medias = _mediaRepository.GetMediaForProduct(id);
            var mediaUrls = medias.Select(d => d.ImgUrl).ToList();

            ViewBag.MediaUrls = mediaUrls;
            return View(model);
        }

        // GET: AdminController/Create
        public IActionResult ProductCreate()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductCreateForm form)
        {
            try
            {
                if (form is null)
                {
                    ModelState.AddModelError(nameof(form), "Form is null");
                    return View(form);
                }
                if (!ModelState.IsValid) return View(form);

                int id = _productRepository.Insert(form.ToBLL());
                
                var medias = new List<string>();
                foreach (var media in form.Medias)
                {
                    if (media != null && media.Length > 0)
                    {
                        var imgUrl = await media.SaveFile();
                        _mediaRepository.Insert(new Media ( imgUrl, id));
                    }
                }
                return RedirectToAction(nameof(Details), new { id= id});
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult ProductEdit(int id)
        {
            ProductEditForm model = _productRepository.GetById(id).ToEdit();
            if(model is null) throw new Exception("Product not found");
            var medias = _mediaRepository.GetMediaForProduct(id);
            var mediaUrls = medias.Select(d => d.ImgUrl).ToList();

            ViewBag.MediaUrls = mediaUrls;
            return View(model);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductEdit(int id, ProductEditForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Product not found");
                if (!ModelState.IsValid) throw new Exception();
                _productRepository.Update(form.ToBLL());
                return RedirectToAction(nameof(Details), new {id = id});
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult ProductDelete(int id)
        {
            ProductDeleteForm model = _productRepository.GetById(id).ToDelete();
            if (model is null) throw new ArgumentOutOfRangeException(nameof(id), "Product not found");
            return View(model);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDelete(int id, ProductDeleteForm form)
        {
            try
            {
                _mediaRepository.DeleteByProductId(id);
                _productRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View(form);
            }
        }
    }
}
