using Microsoft.Extensions.Options;
using Thales.DotNet.Tech.Domain.Services;
using Thales.DotNet.Tech.Infrastructure.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<GeneralConfiguration>(
    builder.Configuration.GetSection(nameof(GeneralConfiguration)));

builder.Services.AddSingleton<IGeneralConfiguration>(sp =>
    sp.GetRequiredService<IOptions<GeneralConfiguration>>().Value);


builder.Services.AddTransient<IEmployeeHandler, EmployeeHandler>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
