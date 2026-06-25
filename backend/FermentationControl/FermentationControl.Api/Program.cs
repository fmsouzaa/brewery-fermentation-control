using FermentationControl.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controllers da API
builder.Services.AddControllers();

// Configura o banco de dados SQLite usando o AppDbContext
// O arquivo brewery.db será criado automaticamente na raiz do projeto
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=brewery.db"));

// Configura o Swagger para documentação e teste dos endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Mapeia os controllers da API
app.MapControllers();

app.Run();
