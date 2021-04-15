using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RezervationSystem.UI.Areas.Identity.Data;
using RezervationSystem.UI.Models;

[assembly: HostingStartup(typeof(RezervationSystem.UI.Areas.Identity.IdentityHostingStartup))]
namespace RezervationSystem.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RezervationContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("PostgreDbContext")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<RezervationContext>();
            });
        }
    }
}