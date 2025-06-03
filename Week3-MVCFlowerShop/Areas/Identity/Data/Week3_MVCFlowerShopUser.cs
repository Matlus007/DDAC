using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Week3_MVCFlowerShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Week3_MVCFlowerShopUser class
public class Week3_MVCFlowerShopUser : IdentityUser
{
    // Modify Tab   le Column Name
    [PersonalData]
    public string? CustomerFullName { get; set; }

    [PersonalData]
    public int CustomerAge { get; set; }

    [PersonalData]
    public string? CustomerAddress { get; set; }

    [PersonalData]
    public DateTime CustomerDOB { get; set; }

    [PersonalData]
    public String userrole { get; set; }
}

