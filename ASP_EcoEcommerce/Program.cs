using ASP_EcoEcommerce.Handlers;
using Shared_EcoEcommerce.Repositories;
using BLL = BLL_EcoEcommerce;
using DAL = DAL_EcoEcommerce;

namespace ASP_EcoEcommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IProductRepository<BLL.Entities.Product>,
                BLL.Services.ProductService>();
            builder.Services.AddScoped<IProductRepository<DAL.Entities.Product>,
                DAL.Services.ProductService>();

            builder.Services.AddScoped<IMediaRepository<BLL.Entities.Media>,
                BLL.Services.MediaService>();
            builder.Services.AddScoped<IMediaRepository<DAL.Entities.Media>,
                DAL.Services.MediaService>();

            builder.Services.AddScoped<IOrderItemRepository<BLL.Entities.OrderItem>,
                BLL.Services.OrderItemService>();
            builder.Services.AddScoped<IOrderItemRepository<DAL.Entities.OrderItem>,
                DAL.Services.OrderItemService>();

            builder.Services.AddScoped<ICartRepository<BLL.Entities.Cart>,
                BLL.Services.CartService>();
            builder.Services.AddScoped<ICartRepository<DAL.Entities.Cart>,
                DAL.Services.CartService>();

            #region Services de session
            builder.Services.AddHttpContextAccessor();  //Injection de dépendance du HttpContext dans le SessionManager (Handlers)
            //builder.Services.AddScoped<CartSessionManager>();  //Injection de dépendance du SessionManager dans le contr?leur
            builder.Services.AddDistributedMemoryCache();   //Ajout d'espace mémoire pour lier les cookie ?l'application

            builder.Services.AddSession(options =>          //Création d'un cookie pour sauvegarder la session
            {
                options.Cookie.Name = "ASP-EcoEcommerce-Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            builder.Services.Configure<CookiePolicyOptions>(options =>  //Définition des règles (pour être OK avec le RGPD)
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });


            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();       
            app.UseCookiePolicy();  
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}