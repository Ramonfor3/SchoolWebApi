using DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

RepositoryConfiguration.AddRepository(builder.Services, builder.Configuration);


//builder.Services.AddScoped<ISchoolService, SchoolService>();
////
//builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
