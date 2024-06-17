using Microsoft.EntityFrameworkCore;
using EvolveDb;
using Serilog;
using MySqlConnector;
using turbo_engine.Business.Implementations;
using turbo_engine.Business;
using turbo_engine.Model.Context;
using turbo_engine.Repository;
using turbo_engine.Repository.Generic;
using Microsoft.Net.Http.Headers;
using turbo_engine.HyperMedia.Filters;
using turbo_engine.HyperMedia.Enricher;
using System.Reflection;
using System.ComponentModel;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var appName = "Testeeeee";
var appVersion = "v1";
var appDescription = $"Descrição de '{appName}'";

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
})
.AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

//Versioning API
builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc(appVersion,
    new OpenApiInfo
    {
            Title = appName,
            Version = appVersion,
            Description = appDescription,
            Contact = new OpenApiContact
            {
                Name = "Luis",
                Url = new Uri("https://api.luisrenato.com.br")
            }
        });
});

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Swagger
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} - {appVersion}"); });
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}