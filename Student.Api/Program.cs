using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using Student.Application.Commands.GetStudent;
using Student.Persistence.DatabaseContext;
using Student.Application.Contracts;
using Student.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add controllers
builder.Services.AddControllers();

// 🔹 Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Register DbContext
builder.Services.AddDbContext<ServiceDatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("StudentConnectionString"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("StudentConnectionString"))
    ));

// 🔹 Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetStudentQueryHandler>());

// 🔹 Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 🔹 Register repositories
builder.Services.AddScoped<IStudent, StudentRepository>();

var app = builder.Build();

// 🔹 Apply migrations automatically (dev only)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ServiceDatabaseContext>();
    db.Database.Migrate();
}

// 🔹 Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
