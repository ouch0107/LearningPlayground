using LearningPlayground.Context;
using LearningPlayground.Models.RandomModel;
using LearningPlayground.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Dapper context
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# region Models
builder.Services.AddScoped<IRandomModel, LotteryModel>();
#endregion

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
else
{
    // Use swagger in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
