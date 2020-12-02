using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebsitePortfolioJTorres.Shared.Interfaces;
using WebsitePortfolioJTorres.Client.Services;
using Tewr.Blazor.FileReader;

namespace WebsitePortfolioJTorres.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("WebsitePortfolioJTorres.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebsitePortfolioJTorres.ServerAPI"));

            builder.Services.AddApiAuthorization();

            //My Services
            //builder.Services.AddTransient<IServiceName, HardcodedMockService>(); //Testing service
            builder.Services.AddTransient<IResumeService, ResumeServices>();
            builder.Services.AddTransient<IBlogService, BlogServices>();
            builder.Services.AddTransient<IProjectService, ProjectServices>();
            builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);// Added to upload files

            await builder.Build().RunAsync();
        }
    }
}
