using Blazored.LocalStorage;
using BugTracker.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

namespace BugTracker.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7082"));

            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
