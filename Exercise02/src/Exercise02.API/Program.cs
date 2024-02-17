using Exercise02.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

ConfigureApp();

app.Run();

void ConfigureServices()
{
    builder.AddCustomerDbContext(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplicationServices();
}

void ConfigureApp()
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.InitalizeInternalCustomerArray();

    app.MapControllers();
}

public partial class Program { }
