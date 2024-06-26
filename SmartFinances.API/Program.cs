using Microsoft.OpenApi.Models;
using SmartFinances.API.Middleware;
using SmartFinances.Application;
using SmartFinances.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.EnableAnnotations();
    opt.MapType<decimal>(() => new OpenApiSchema { Type = "number", Format = "decimal" });
});
builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureInfractructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices(builder.Configuration);
builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", q => q.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
