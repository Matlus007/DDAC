using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Week3_MVCFlowerShop.Areas.Identity.Data;

namespace Week3_MVCFlowerShop.Data;

public class Week3_MVCFlowerShopContext : IdentityDbContext<Week3_MVCFlowerShopUser>
{
    public Week3_MVCFlowerShopContext(DbContextOptions<Week3_MVCFlowerShopContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
