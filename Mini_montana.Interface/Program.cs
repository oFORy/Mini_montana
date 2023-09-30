using Microsoft.Extensions.Configuration;
using Mini_montana.Application;
using Mini_montana.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var origins = builder.Configuration.GetSection("CorsOrigins:Urls").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "enablecorspolicy",
                      builder =>
                      {
                          builder.WithOrigins(origins);
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowCredentials();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
