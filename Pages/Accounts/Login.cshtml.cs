

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Miro.Helpers;

namespace Miro.Pages.Accounts;
public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    private readonly MiroDbContext _context;

    public LoginModel(ILogger<LoginModel> logger, MiroDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public String Email { get; set; }
    [BindProperty]
    public String Password { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        

        var user = _context.User.FirstOrDefault(u => u.Email == Email && u.Password == Mirohash.ComputeHashSha256(Password));

        if (user == null)
        {
            ModelState.AddModelError(String.Empty, "ایمیل و پسورد را به صورت صحیح وارد کنید.");
            return Page();
        }

        var claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role.ToString())
        };

        var claimsIdentity = new System.Security.Claims.ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme
        );

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2)
        };


        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new System.Security.Claims.ClaimsPrincipal(claimsIdentity),
            authProperties
        );


        if (Request.Query["ReturnUrl"].ToString() != null && Url.IsLocalUrl(Request.Query["ReturnUrl"]))
        {

            return Redirect(Request.Query["ReturnUrl"]);
        }

        return RedirectToPage("/Index");
    }


}