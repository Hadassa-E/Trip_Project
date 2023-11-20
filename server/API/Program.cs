using API;
using BLL.functionsBLL;
using BLL.interfacesBLL;
using DAL.functionsDAL;
using DAL.interfacesDAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(o=>o.JsonSerializerOptions.PropertyNamingPolicy=null);
builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
try
{
    builder.Services.AddDbContext<TripsDbContext>(x => x.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=TripsDB;Trusted_Connection=True;"));
    builder.Services.AddScoped(typeof(IkindDAL), typeof(func_KindDAL));
    builder.Services.AddScoped(typeof(IorderDAL), typeof(func_OrderDAL));
    builder.Services.AddScoped(typeof(ItripDAL), typeof(func_TripDAL));
    builder.Services.AddScoped(typeof(IuserDAL), typeof(func_UserDAL));
    builder.Services.AddScoped(typeof(IkindBLL), typeof(func_KindBLL));
    builder.Services.AddScoped(typeof(IorderBLL), typeof(func_OrderBLL));
    builder.Services.AddScoped(typeof(ItripBLL), typeof(func_TripBLL));
    builder.Services.AddScoped(typeof(IuserBLL), typeof(func_UserBLL));
}
catch (Exception ex) { }

finally
{
    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("AllowAll");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

