

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Helpers;
using Miro.Models;
using System.Text.Json;

namespace Miro.Pages;

public class CartModel : PageModel
{
    private ILogger<CartModel> _logger;
    private readonly CartHelper _cartHelper;
    public List<CartItem> Cart { get; set; }
    public string CartTotalString { get; set; }
    public string FromatPrice(decimal price)
    {
        return _cartHelper.FromatPrice(price);
    }

    public CartModel(ILogger<CartModel> logger, CartHelper cartHelper)
    {
        _logger = logger;
        _cartHelper = cartHelper;
    }

    public void OnGet()
    {
        Cart = _cartHelper.GetCart();
        CartTotalString = FromatPrice(_cartHelper.GetCartTotal());
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("/Cart");
    }

    public IActionResult OnPostAddToCart(int id)
    {
        _cartHelper.AddToCart(id);
        return RedirectToPage("/Cart");
    }

    public IActionResult OnPostRemoveFromCart(int id)
    {
        _cartHelper.RemoveFromCart(id);
        return RedirectToPage("/Cart");
    }
}