using Exercise02.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

ConfigureApp();

app.Run();

void ConfigureServices()
{
    builder.Services.AddApplicationServices();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

void ConfigureApp()
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();
}

public partial class Program { }
