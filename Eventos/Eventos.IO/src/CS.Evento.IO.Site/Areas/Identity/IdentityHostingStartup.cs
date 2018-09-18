using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CS.Evento.IO.Site.Areas.Identity.IdentityHostingStartup))]
namespace CS.Evento.IO.Site.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {              
            });
        }
    }
}