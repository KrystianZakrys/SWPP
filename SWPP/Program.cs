using MediatR;
using Microsoft.EntityFrameworkCore;
using SWPP.Core.Command.Module;
using SWPP.Infrastructure;
using SWPP.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(AddNewModuleCommand).GetTypeInfo().Assembly);

builder.Services.AddDbContext<SWPPContext>(o =>
{
    o.UseSqlServer(builder.Configuration["connectionStrings:SWPPDbConnectionString"], b => b.MigrationsAssembly("SWPP.WebApi"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(new ExceptionHandlerOptions()
{
    ExceptionHandler = new ExceptionMiddleware().Invoke
});

app.MapControllers();

app.Run();
