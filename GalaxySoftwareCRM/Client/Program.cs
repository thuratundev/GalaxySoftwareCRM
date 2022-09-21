using GalaxySoftwareCRM.Client;
using GalaxySoftwareCRM.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ActionService>();
builder.Services.AddScoped<FilterService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpClient<IDataService, DataService>(client =>
{
     // client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
      client.BaseAddress = new Uri("http://localhost:99/");
});

builder.Services.AddMudServices();

await builder.Build().RunAsync();
