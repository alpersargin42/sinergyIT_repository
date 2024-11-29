using Microsoft.EntityFrameworkCore;
using Repository_Pratik.Databases.DbContext;
using Repository_Pratik.Databases.Storage;
using Repository_Pratik.Services;
using AutoMapper;
using Repository_Pratik.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UrunDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddAutoMapper(typeof(HaritalamaProfili)); 
builder.Services.AddScoped<UrunDeposu>();  
builder.Services.AddScoped<UrunServisi>(); 


builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();  

var app = builder.Build();  


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI();  
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();