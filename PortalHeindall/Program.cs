using AppHeindall.Interfaces;
using AppHeindall.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IGrupoService, GrupoService>(services =>
            services.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings:UrlLocal").Value));

builder.Services.AddHttpClient<IIntegradorDoUsuarioService, IntegradorDoUsuarioService>(services =>
            services.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings:UrlLocal").Value));

builder.Services.AddHttpClient<IIntegradorService, IntegradorService>(services =>
            services.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings:UrlLocal").Value));

builder.Services.AddHttpClient<IMetaService, MetaService>(services =>
            services.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings:UrlLocal").Value));

builder.Services.AddHttpClient<IUsuarioService, UsuarioService>(services =>
            services.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings:UrlLocal").Value));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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