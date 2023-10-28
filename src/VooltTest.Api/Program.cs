using VooltTest.Application.Configuration;
using VooltTest.Data.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddData();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
