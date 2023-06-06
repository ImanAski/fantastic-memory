using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Helpers;
using Miro.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Miro.Pages;

public class CheckoutModel : PageModel
{

    private readonly ILogger<CheckoutModel> _logger;
    private readonly MiroDbContext _dbContext;
    public List<CartItem> Cart { get; set; }
    public CartHelper _cartHelper { get; set; }
    public string CartTotalString { get; set; }
    public IEnumerable<Province>? Provinces { get; set; }
    public IEnumerable<City>? Cities { get; set; }
    public int ProvinceId { get; set; }
    public int CityId { get; set; }
    [BindProperty]
    public Order Order { get; set; }
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

        string cityData = System.IO.File.ReadAllText("Data/shipment/cities.json");
        string provinceData = System.IO.File.ReadAllText("Data/shipment/provinces.json");
        Cities = JsonConvert.DeserializeObject<List<City>>(cityData);
        Provinces = JsonConvert.DeserializeObject<List<Province>>(provinceData);

        return Page();
    }

    public async Task<IActionResult> OnPostSubmitOrder()
    {
        
        if (!ModelState.IsValid)
        {
            ViewData["Error"] = "مشکلی در پردازش داده ها پیش آمده است";
            return Page();
        }

        try
        {
            // await _dbContext.Order.AddAsync(Order);
            // await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            ViewData["Error"] = "مشکلی در ثبت سفارش وجود دارد.";
        }


        return RedirectToPage("/OrderVerification/", new { orderId = Order.Id});
    }

    public JsonResult OnGetCitiesForProvince(int provinceId)
    {
        string cityData = System.IO.File.ReadAllText("Data/shipment/cities.json");
        List<City> CitiesForProvince = JsonConvert.DeserializeObject<List<City>>(cityData);

        return new JsonResult(CitiesForProvince.Where(c => c.province_id == provinceId));
    }
}