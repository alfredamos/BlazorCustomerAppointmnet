using BlazorCustomerAppointmnet.Client.Contracts;
using BlazorCustomerAppointmnet.Client.Mapings;
using BlazorCustomerAppointmnet.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCustomerAppointmnet.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("BlazorCustomerAppointmnet.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorCustomerAppointmnet.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerSupportService, CustomerSupportService>();
            builder.Services.AddScoped<ICustomerSupportAppointmentService, CustomerSupportAppointmentService>();
            
            builder.Services.AddAutoMapper(typeof(Map));

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            await builder.Build().RunAsync();
        }
    }
}
