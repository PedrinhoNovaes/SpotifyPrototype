using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Application.Conta;
using SpotifyPrototype.Application.Conta.Profile;
using SpotifyPrototype.Application.Streaming;
using SpotifyPrototype.Repository;
using SpotifyPrototype.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpotifyPrototypeContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyPrototypeConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Permitir apenas requisições do endereço da sua aplicação Angular
               .AllowAnyMethod() // Permitir todos os métodos HTTP (GET, POST, PUT, DELETE, etc.)
               .AllowAnyHeader(); // Permitir todos os cabeçalhos HTTP
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Habilitar o middleware CORS
app.UseAuthorization();
app.MapControllers();
app.Run();
