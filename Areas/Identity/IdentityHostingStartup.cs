[assembly: HostingStartup(typeof(IdentityBlazor.Areas.Identity.IdentityHostingStartup))]
namespace IdentityBlazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}