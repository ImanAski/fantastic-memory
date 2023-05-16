

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Miro.Pages;

public class PricesModel : PageModel
{
    private readonly ILogger<PricesModel> _logger;
    private readonly MiroDbContext _dbContext;
    public IList<Product> Products { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public string SearchTerm { get; set; }

    public PricesModel(ILogger<PricesModel> logger, MiroDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task OnGetAsync(string searchTerm, int? pageIndex)
    {
        IQueryable<Product> products = _dbContext.Product;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            products = products.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
        }

        SearchTerm = searchTerm;

        int pageSize = 6;
        PageIndex = pageIndex ?? 1;
        TotalPages = (int) Math.Ceiling(await products.CountAsync() / (double)pageSize);

        Products = await products.Skip((PageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        
    }
}