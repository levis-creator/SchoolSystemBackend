using Microsoft.EntityFrameworkCore;
using SchoolSystemBackend.Data;
using SchoolSystemBackend.Repositories;
using SchoolSystemBackend.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/***************************************************************/
//add repository injection
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IClassStreamRepository, ClassStreamRepository>();
builder.Services.AddScoped<IGradesRepository, GradeRepository>();
builder.Services.AddScoped <INextOfKinRepository, NextOfKinRepository>();

/**************************************************************/

builder.Services.AddCors(options => options.AddPolicy(
    name: "MyPolicy",
    policy => policy.WithOrigins(
        "http://localhost:3000"
        )
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
