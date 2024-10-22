using BookManager.Application.Command.CreateBook;
using BookManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using BookManager.Domain.Repositories;
using BookManager.Infrastructure.Repositories;  // Adiciona este namespace para configurar o Swagger

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container

// Configuração do DbContext com SQL Server
builder.Services.AddDbContext<BookManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagercs")));

// Configuração do MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IDevolutionRepository, DevolutionRepository>();
builder.Services.AddScoped<ILoanRepository, LoansRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookManager API",
        Version = "v1"
    });
});

// Adicionar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // Necessário para Swagger com minimal APIs

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Gera o documento Swagger
    app.UseSwaggerUI(c =>  // Configura a interface do Swagger UI
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManager API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
