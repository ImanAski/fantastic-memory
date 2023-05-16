using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Miro.Data;
using Miro.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "AdminOnly");
});
builder.Services.AddDbContext<MiroDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("MiroDb")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Accounts/Login";
        // options.AccessDeniedPath = "/Accounts/AccessDenied";
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == System.Security.Claims.ClaimTypes.Role && c.Value == "admin"
            )
        );
    });
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(3);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// builder.Services.AddSingleton<CartHelper>();
builder.Services.AddScoped<CartHelper>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MiroDbContext>();
    DbInitializer.Initialize(context);
}

app.Run();
