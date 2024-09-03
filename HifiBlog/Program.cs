using HifiBlog.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HifiContext>(options=>{
    var config =builder.Configuration;
    var connectionString = config.GetConnectionString("Sql_connection");
    options.UseSqlite(connectionString);
});
var app = builder.Build();
app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Home}/{id?}");
app.Run();