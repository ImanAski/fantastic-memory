

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Miro.Pages;

public class PricesModel : PageModel
{
    private readonly ILogger<PricesModel> _logger;

    public PricesModel(ILogger<PricesModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["Hello"] = "This is it";
    }
}