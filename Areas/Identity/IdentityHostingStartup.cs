using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Track_Sport_Events_MVC.Models;

[assembly: HostingStartup(typeof(Track_Sport_Events_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Track_Sport_Events_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Track_Sport_Events_IDContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Track_Sport_Events_IDContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Track_Sport_Events_IDContext>();
            });
        }
    }
}