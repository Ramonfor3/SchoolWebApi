using DependencyInjection;
using Serilog;
using Serilog.Core;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

RepositoryConfiguration.AddRepository(builder.Services, builder.Configuration);

#region SeriLog

Log.Logger = new LoggerConfiguration()

    // Add console (Sink) as logging target
    .WriteTo.Console()

    // Set default minimum log level
    .MinimumLevel.Debug()

    // Create the actual logger
    .CreateLogger();

Console.WriteLine("Hello, World!");

Log.CloseAndFlush();
#endregion


builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddControllers();
//builder.Services.AddScoped<IService, Service>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(options =>
                options.EnrichDiagnosticContext = async (diagnosticContext, context) =>
                {
                    context.Request.EnableBuffering();
                    context.Request.Body.Position = 0;
                    var bodyPased = await new StreamReader(context.Request.Body).ReadToEndAsync();


                    if (!string.IsNullOrEmpty(bodyPased))
                    {
                        var bodyJson = JsonSerializer.Deserialize<object>(bodyPased);

                        diagnosticContext.Set("Body", bodyJson);
                        options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} {Body} responded {StatusCode} in {Elapsed:0.0000}";
                    }
                }
            );

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
