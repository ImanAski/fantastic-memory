

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Miro.Pages.Admin
{
    public class UserModel : PageModel
    {
        private readonly ILogger<UserModel> _logger;
        private MiroDbContext _context;
        [BindProperty]
        public User user {get;set;}
        [BindProperty]
        public int ID { get; set; }

        public UserModel(ILogger<UserModel> logger, MiroDbContext context)
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

            var hashedPassword = Helpers.Mirohash.ComputeHashSha256(user.Password);
            var insertUser = new User{
                Name = user.Name,
                Email = user.Email,
                Password = hashedPassword,
                Role = user.Role == "admin" ? "admin" : "user"
            };
            try{
                await _context.AddAsync(insertUser);
                await _context.SaveChangesAsync();
            }catch(Exception e) {
                ViewData["Error"] = e.Message;
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {

            var user = _context.User.FirstOrDefault(u => u.ID == ID);

            if (user == null)
            {
                ViewData["Error"] = "There was a problem";
                return Page();
            }

            try {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            } catch(Exception e) {
                ViewData["Error"] = e.Message;
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var newUser = _context.User.FirstOrDefault(u => u.ID == user.ID);

            if (newUser == null)
            {
                ViewData["Error"] = "There was a problem finding user";
                return Page();
            }

            newUser.Email = user.Email;
            newUser.Name = user.Name;
            newUser.Role = user.Role == "admin" ? "admin" : "user";
            if(!String.IsNullOrWhiteSpace(user.Password))
            {
                newUser.Password = Miro.Helpers.Mirohash.ComputeHashSha256(user.Password);
            }
            

            try{
                _context.User.Update(newUser);
                await _context.SaveChangesAsync();
            }catch (Exception e){
                ViewData["Error"] = e.Message;
                return Page();
            }

            return Page();
        }
    }
}