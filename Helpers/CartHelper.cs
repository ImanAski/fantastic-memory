
using System.Text.Json;
using Miro.Models;

namespace Miro.Helpers;

public class CartHelper
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly MiroDbContext _dbContext;

    public CartHelper(IHttpContextAccessor httpContextAccessor, MiroDbContext dbContext)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public List<CartItem> GetCart()
    {
        var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");
        if (cartJson == null)
        {
            return new List<CartItem>();
        }
        return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
    }

    public void SaveCart(List<CartItem> cart)
    {
        var cartJson = JsonSerializer.Serialize(cart);
        _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
    }

    public void AddToCart(int id)
    {
        var product = _dbContext.Product.Find(id);
        if (product != null)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Id = id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            SaveCart(cart);
        }
    }

    public void RemoveFromCart(int id)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            cart.Remove(item);
            SaveCart(cart);
        }
    }

    public string FromatPrice(decimal price)
    {
        return price.ToString("#,##0 تومان");
    }

    public static string FormatPrice(decimal price)
    {
        return price.ToString("#,##0 تومان");
    }
    public decimal GetCartTotal()
    {
        var cart = GetCart();
        return cart.Sum(item => item.Price * item.Quantity);
    }

    public void UpdateQuantity(int id, int quantity)
    {
        var cart = GetCart();
        var cartItem = cart.FirstOrDefault(i => i.Id == id);
        if (cartItem != null)
        {
            cartItem.Quantity = quantity;
            SaveCart(cart);
        }
    }


}