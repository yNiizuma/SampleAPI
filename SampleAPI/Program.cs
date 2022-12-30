using Microsoft.EntityFrameworkCore;
using SampleAPI.Model;
using SampleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SampleContext>(x => x.UseInMemoryDatabase(databaseName: "SampleDB"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISampleRepository, SampleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

