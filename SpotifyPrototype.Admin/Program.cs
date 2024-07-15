using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotifyPrototype.Application.Conta;
using SpotifyPrototype.Application.Streaming;
using SpotifyPrototype.Application;
using SpotifyPrototype.Repository;
using SpotifyPrototype.Repository.Repository.Admin;
using SpotifyPrototype.Repository.Repository;
using SpotifyPrototype.Application.Admin.Profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SpotifyPrototypeAdminContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyPrototypeAdminConnection"));
});
builder.Services.AddDbContext<SpotifyPrototypeContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyPrototypeConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioAdminProfile).Assembly);

builder.Services.AddScoped<UsuarioAdminService>();
builder.Services.AddScoped<UsuarioAdminRepository>();

// Repository
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<EstiloMusicalRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<MusicaRepository>();

// Service
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<CartaoService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<EstiloMusicalService>();


builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
