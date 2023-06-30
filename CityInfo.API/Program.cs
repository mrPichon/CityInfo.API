using CityInfo.API;
using CityInfo.API.DbContexts;
using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

// use serilog: install packages
// install-package serilog.aspnetcore, serilog.sinks.file and serilog.sinks.console
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// enable serilog
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers( options =>
{
    // Content Negotiation
    options.ReturnHttpNotAcceptable = true; // return 406 when the Accept header is diferent than application/json
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters(); // add suport to Accept xml requests

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>(); // map file extensions (see filesController)

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
    builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddDbContext<CityInfoContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));

// create once by request
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
// adding this, you should create the profile forder and class to map
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello world");
//});

app.Run();
