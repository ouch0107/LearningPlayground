using LearningPlayground.Context;
using LearningPlayground.Models.RandomModel;
using LearningPlayground.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Dapper context
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddControllersWithViews();
// Dependency Injection for random model per request
builder.Services.AddScoped<IRandomModel, LotteryModel>();

#region Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
