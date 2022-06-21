using Microsoft.Extensions.Options;
using ToDoApiSWS.Models;

var builder = WebApplication.CreateBuilder(args);

// Gonzalo
ConfigurationManager configuration = builder.Configuration;
// IWebHostEnvironment environment = builder.Environment;
//

// Add services to the container.

// Gonzalo
builder.Services.Configure<TareaDatabaseSettings>(
        configuration.GetSection(nameof(TareaDatabaseSettings)));
builder.Services.AddSingleton<ITareaDatabaseSettings>(provider =>
    provider.GetRequiredService<IOptions<TareaDatabaseSettings>>().Value);
builder.Services.AddScoped<TareaService>();
//

builder.Services.AddControllers();
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

// Gonzalo
app.UseStaticFiles();
//

// Gonzalo
// app.UseHttpsRedirection();
// app.UseAuthorization();
//

app.MapControllers();

app.Run();
