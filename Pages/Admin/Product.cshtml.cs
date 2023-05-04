

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Miro.Pages.Admin
{
    public class ProductModel : PageModel
    {
        private MiroDbContext _context;
        private readonly ILogger<ProductModel> _logger;
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public int ID { get; set; }


        public ProductModel(ILogger<ProductModel> logger, MiroDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var insertProduct = new Product{
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                InStock = product.InStock
            };

            try{
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
            }catch (Exception e) {
                ViewData["Error"] = e.Message;
                return Page();
            }

            return Page();

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var product = _context.Product.FirstOrDefault(p => p.ID == ID);

            if (product == null)
            {
                ViewData["Error"] = "No Product Found";
                return Page();
            }
            try {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            } catch (Exception e) {
                ViewData["Error"] = e.Message;
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var newProduct = _context.Product.FirstOrDefault(p => p.ID == product.ID);

            if (newProduct == null)
            {
                ViewData["Error"] = "No Product was found";
                return Page();
            }

            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.InStock = Request.Form["InStock"] == "on";

            try{
                _context.Product.Update(newProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ViewData["Error"] = e.Message; 
                return Page();
            }

            return Page();
        }

        // public async Task<IActionResult> OnPostDeleteAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     var product 
        // }
    }
}