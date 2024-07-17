using System.Net.NetworkInformation;
using System.Reflection;
using Categories.API.v1.DBRepo;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    // Specify the default API version as 1.0
    options.DefaultApiVersion = new ApiVersion(1, 0);
    // Assume that the client wants the default version if they don't specify one
    options.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    options.ReportApiVersions = true;
});

// Init configs
string MongoDBConnectionString = string.Empty;
// If the environment is development, use configurations that are stored in the appsettings.Development.json file
if (builder.Environment.IsDevelopment())
{
    MongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection") ?? throw new ArgumentNullException("MongoDBConnection");
}
// If the environment is production, use configurations that are stored in the appsettings.json file
else
{

}

// Register MongoDB client as a singleton using the connection string directly
builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
{
    return new MongoClient(MongoDBConnectionString);
});

builder.Services.AddScoped<IMongoDBRepository, MongoDBRepository>();

// Inject MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();

var app = builder.Build();

// Use Swagger in development for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();