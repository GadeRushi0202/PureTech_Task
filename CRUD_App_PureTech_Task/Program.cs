using CRUD_App_PureTech_Task.Data;
using CRUD_App_PureTech_Task.Repository;
using CRUD_App_PureTech_Task.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionstring = builder.Configuration.GetConnectionString("defaultconnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionstring));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddSession(session =>
{
    session.IdleTimeout = TimeSpan.FromSeconds(60);
    session.Cookie.IsEssential = true;
});
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
app.UseSession();   
app.Run();
