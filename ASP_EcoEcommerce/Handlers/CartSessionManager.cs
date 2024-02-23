
using BLL_EcoEcommerce.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace ASP_EcoEcommerce.Handlers
{
    public class CartSessionManager : SessionManager
    {
        public Dictionary<Product, int> Cart
        {
            get
            {
                string cartJson = _session.GetString("Cart");
                return !string.IsNullOrEmpty(cartJson) ? JsonSerializer.Deserialize<Dictionary<Product, int>>(cartJson) : new Dictionary<Product, int>();
            }
            set
            {
                _session.SetString("Cart", JsonSerializer.Serialize(value));
            }
        }

        public CartSessionManager(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public void AddToCart(Product product, int quantity)
        {
            
                Dictionary<Product, int> newCart = Cart;
            if (newCart.ContainsKey(product))
            {
                newCart[product]+= quantity;
            }
            else
            {
                newCart.Add(product, quantity);

            }
                Cart = newCart;
        }

    }
}
