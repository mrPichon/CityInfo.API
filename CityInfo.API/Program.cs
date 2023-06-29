using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

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
