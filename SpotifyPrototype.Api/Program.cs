using Microsoft.EntityFrameworkCore;
using SpotifyPrototype.Application.Account;
using SpotifyPrototype.Application.Account.Profile;
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
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
});


builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);


//Repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PlanRepository>();
builder.Services.AddScoped<BandRepository>();

//Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BandService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
