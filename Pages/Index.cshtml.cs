using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace miro.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MiroDbContext _dbContext;
    public IList<Product> Products { get; set; }
    public IList<Product> LatesProducts { get; set; }

    public IndexModel(ILogger<IndexModel> logger, MiroDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public void OnGet()
    {
        IQueryable<Product> products = _dbContext.Product;

        LatesProducts = products.OrderBy(s => s.DateAdded).Take(6).AsNoTracking().ToList();
    }
}
