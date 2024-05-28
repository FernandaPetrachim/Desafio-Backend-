using Microsoft.Data.Sqlite;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuariosAPI", Version = "v1" });
});

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

using (var command = connection.CreateCommand())
{
    command.CommandText = @"
CREATE TABLE Usuarios (
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Nome TEXT NOT NULL,
Email TEXT NOT NULL,
SenhaHash TEXT NOT NULL,
CPF TEXT NOT NULL,
Nascimento TEXT NOT NULL
)";
    command.ExecuteNonQuery();
}

builder.Services.AddSingleton<IDbConnection>(connection);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosAPI v1"));
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();