using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = new SqliteConnection($"Data Source=C:\\hotellistdb\\hotellist.db");
builder.Services.AddDbContext<HotelListingDBContext>(o => o.UseSqlite(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

// ctx =context, lc = logger configuration
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// log the type of requests coming in and how long they took to response
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

