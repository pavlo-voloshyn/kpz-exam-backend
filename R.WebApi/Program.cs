using R.WebApi.Extensions;
using R.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMapperProfiles();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
       options => options
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
   );

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
