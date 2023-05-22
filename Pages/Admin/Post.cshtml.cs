using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Miro.Pages.Admin;

public class Post : PageModel
{
    private readonly MiroDbContext _dbContext;

    public Post(MiroDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void OnGet()
    {
        
    }
}