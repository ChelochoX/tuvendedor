using System.Reflection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "Documentacion API de Gestion de Ventas",
    Version = "v1",
    Description = "REST API Sistema de Gestion de Ventas"
});
c.EnableAnnotations();
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
c.IncludeXmlComments(xmlPath);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Aplicacion Iniciada Correctamente");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
