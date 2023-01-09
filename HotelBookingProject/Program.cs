using HotelBooking.Model;
using HotelBookingProject.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<HotelBookingDBContext>(options =>
{
    object value = options.UseMySql(builder.Configuration.GetConnectionString("SqlConnection"), serverVersion);
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRegister, RegisterService>();
builder.Services.AddScoped<ILogin, LoginService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

