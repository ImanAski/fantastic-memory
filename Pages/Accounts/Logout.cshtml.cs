


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Helpers;

namespace Miro.Pages.Accounts;
public class LogoutModel : PageModel
{
    private readonly ILogger<LogoutModel> _logger;
    private readonly MiroDbContext _context;
    
    public LogoutModel(ILogger<LogoutModel> logger, MiroDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Index");
    }
}