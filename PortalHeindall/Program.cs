using Microsoft.EntityFrameworkCore;
using PortalHeindall.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

///////////////////

/* builder.Services.AddDbContext<GrupoContext>
   (options => options.UseMySql(
       "server=localhost;initial catalog=heindall;uid=root;pwd=123456",
       Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.2.42-mysql")));*/


builder.Services.AddDbContext<GrupoContext>
    (options => options.UseMySql(
        "server=185.239.210.205;initial catalog=u839385910_heindall;uid=u839385910_heindall;pwd=Aa@heindall23",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.05.00-MariaDB")));

/////////////////////



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
