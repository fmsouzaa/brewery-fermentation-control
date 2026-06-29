using FermentationControl.Api.Data;
using FermentationControl.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controllers da API
builder.Services.AddControllers();

// Configura o banco de dados SQLite usando o AppDbContext
// O arquivo brewery.db será criado automaticamente na raiz do projeto
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=brewery.db"));

// Registra o MediatR e escaneia automaticamente todos os Handlers da aplicação
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Registra o serviço de classificação fermentativa para injeção de dependência
builder.Services.AddScoped<FermentationClassificationService>();

// Configura o Swagger para documentação e teste dos endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Informações gerais da API
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Brewery Fermentation Control API",
        Version = "v1",
        Description = "API para registro e acompanhamento de dados fermentativos de cervejarias."
    });

    // Habilita os comentários XML no Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // ← porta do Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Habilita o Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita o HTTPS
app.UseHttpsRedirection();

// Habilita a autorização
app.UseAuthorization();

// Depois do builder.Build()
app.UseCors("AllowFrontend"); // ← ativar o CORS

// Mapeia os controllers da API
app.MapControllers();

app.Run();
