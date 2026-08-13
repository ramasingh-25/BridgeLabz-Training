using ContactApp.BLL.Interfaces;
using ContactApp.BLL.Services;
using ContactApp.DAL.Data;
using ContactApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// =====================================================
// DATABASE
// =====================================================

builder.Services.AddDbContext<ContactDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    );
});


// =====================================================
// DEPENDENCY INJECTION
// =====================================================

// Repository - DAL implementation
builder.Services.AddScoped<
    IContactRepository,
    ContactRepository>();


// Service - BLL implementation
builder.Services.AddScoped<
    IContactService,
    ContactService>();


// =====================================================
// CONTROLLERS
// =====================================================

builder.Services.AddControllers();


// =====================================================
// SWAGGER
// =====================================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();


// =====================================================
// SWAGGER
// =====================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


// =====================================================
// HTTPS
// =====================================================

app.UseHttpsRedirection();


// =====================================================
// CONTROLLERS
// =====================================================

app.MapControllers();


app.Run();