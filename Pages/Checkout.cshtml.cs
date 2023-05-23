


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Helpers;
using Miro.Models;

namespace Miro.Pages;

public class CheckoutModel : PageModel
{

    private readonly ILogger<CheckoutModel> _logger;
    private readonly MiroDbContext _dbContext;
    public List<CartItem> Cart { get; set; }
    public CartHelper _cartHelper { get; set; }
    public string CartTotalString { get; set; }
    
    public string FormatPrice(decimal price)
    {
        return _cartHelper.FromatPrice(price);
    }

    public CheckoutModel(ILogger<CheckoutModel> logger, MiroDbContext dbContext, CartHelper cartHelper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _cartHelper = cartHelper;
    }

    public IActionResult OnGet()
    {
        
        Cart = _cartHelper.GetCart();
        if (Cart.Count == 0)
        {
            return RedirectToPage("/Cart");
        }
        CartTotalString = FormatPrice(_cartHelper.GetCartTotal());

        return Page();
    }
}