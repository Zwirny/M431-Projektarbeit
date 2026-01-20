using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Notenverwaltung.Web.Services;
using Notenverwaltung.Web.Services.Abstract;

namespace Notenverwaltung.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp =>
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            var js = sp.GetRequiredService<IJSRuntime>();
            var token = js.InvokeAsync<string>("localStorage.getItem", "token").GetAwaiter().GetResult();

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        });

        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped(sp =>
        {
            var customHandler = new
                CustomHttpHandler(sp.GetRequiredService<IJSRuntime>())
            {
                InnerHandler = new HttpClientHandler()
            };

            var httpClient = new HttpClient(customHandler)
            {
                BaseAddress = new Uri("https://localhost:7008/")
            };
            return httpClient;
        });

        await builder.Build().RunAsync();
    }
}