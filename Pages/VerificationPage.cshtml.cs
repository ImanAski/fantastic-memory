using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Models;
using miro.Services.Interface;

namespace Miro.Pages;

public class VerificationPage : PageModel
{

    private readonly IPaymentService _zarinpalService;
    private readonly IOrderService _orderService;

    public VerificationPage(IPaymentService zarinpalService, IOrderService orderService)
    {
        _orderService = orderService;
        _zarinpalService = zarinpalService;
    }
    
    [BindProperty]
    public string Authority { get; set; }

    public async Task<IActionResult> OnGetAsync(string authroity, int amount, string description)
    {
        if (!String.IsNullOrEmpty(authroity))
        {
            return RedirectToPage("/Index");
        }

        Authority = authroity;

        var paymentRequest = new PaymentRequest
        {
            MerchantId = "",
            Amount = amount,
            Description = description,
            CallbackUrl = Url.Page("/Verification", null, new { authority = Authority, amount = amount }, Request.Scheme)
            
        };
        
        var paymentVerification = await _zarinpalService.VerifyPayment(paymentRequest, Authority);

        if (paymentVerification.IsSuccess)
        {
            // Payment was successful, update the order status and redirect to the success page
            var order = await _orderService.GetOrderByAuthority(Authority);
            order.Status = OrderStatus.Paid;
            await _orderService.UpdateOrder(order);

            return RedirectToPage("/Success");
        }
        else
        {
            // Payment failed, redirect to the error page
            return RedirectToPage("/Error");
        }
    }
}