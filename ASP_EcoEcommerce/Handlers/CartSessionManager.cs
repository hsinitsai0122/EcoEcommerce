
using BLL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace ASP_EcoEcommerce.Handlers
{
    public class CartSessionManager : SessionManager
    {
        public Dictionary<int, int> Cart
        {
            get
            {
                string cartJson = _session.GetString("Cart");
                return !string.IsNullOrEmpty(cartJson) ? JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) : new Dictionary<int, int>();
            }
            set
            {
                _session.SetString("Cart", JsonSerializer.Serialize<Dictionary<int, int>>(value));
            }
        }

        public CartSessionManager(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public void AddToCart(Product product, int quantity)
        {
            
                Dictionary<int, int> newCart = Cart;
            if (newCart.ContainsKey(product.Id_Product))
            {
                newCart[product.Id_Product]+= quantity;
            }
            else
            {
                newCart.Add(product.Id_Product, quantity);

            }
                Cart = newCart;
        }

    }
}
