using CatalogoApi.Data;
using Microsoft.EntityFrameworkCore;


// Cria o construtor da aplicação web.
var builder = WebApplication.CreateBuilder(args);

// --- SEÇÃO DE CONFIGURAÇÃO DE SERVIÇOS ---

// Adiciona os serviços de Controllers (para que a API encontre seu LivrosController).
builder.Services.AddControllers();

// Configuração de conexão bando de dados SQLite
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adiciona os serviços necessários para o Swagger funcionar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- SEÇÃO DE CONFIGURAÇÃO DA APLICAÇÃO ---

// Constrói a aplicação.
var app = builder.Build();

// Configura para usar o Swagger apenas no ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

// Força o uso de HTTPS.
app.UseHttpsRedirection();

// Configura o roteamento para os seus controllers.
app.MapControllers();

// Executa a aplicação.
app.Run();