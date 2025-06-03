using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Week3_MVCFlowerShop.Data;
using Week3_MVCFlowerShop.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Week3_MVCFlowerShopContextConnection") ?? throw new InvalidOperationException("Connection string 'Week3_MVCFlowerShopContextConnection' not found.");

builder.Services.AddDbContext<Week3_MVCFlowerShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Week3_MVCFlowerShopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Week3_MVCFlowerShopContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Focus on the Razor page 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
