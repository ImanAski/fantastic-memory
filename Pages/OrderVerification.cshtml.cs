using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Models;
using miro.Services.Interface;

namespace Miro.Pages;

public class OrderVerification : PageModel
{
    public string OrderId { get; set; }
    public bool HasViewedThePage { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOrderService _orderService;
    public Order Order { get; set; }

    public OrderVerification(IHttpContextAccessor httpContextAccessor, IOrderService orderService)
    {
        _orderService = orderService;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<IActionResult> OnGetAsync(string orderId)
    {
        if (String.IsNullOrEmpty(orderId))
        {
            return RedirectToAction("/Index");
        }

        OrderId = orderId;
        Order = await _orderService.GetOrderById(Int32.Parse(orderId));
        var session = _httpContextAccessor.HttpContext.Session;
        var key = $"HasViewedOrderVerificationPage_{orderId}";
        if (session.TryGetValue(key, out byte[] value))
        {
            HasViewedThePage = true;
            return RedirectToPage("/Index");
        }
        else
        {
            HasViewedThePage = false;
            session.Set(key, new byte[]{1});
        }
        return Page();
    }
}