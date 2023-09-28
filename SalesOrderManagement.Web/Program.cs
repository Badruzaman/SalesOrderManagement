using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.10.83.153:70") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7096") });
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IDimensionService, DimensionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();

await builder.Build().RunAsync();
