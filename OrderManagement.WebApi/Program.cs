using Hangfire;
using OrderManagement.Application;
using OrderManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

var dbBackgroundJobConnection = builder.Configuration.GetConnectionString("DbBackgroundJobConnection");
builder.Services.AddHangfire(
    config => 
        config.UseSqlServerStorage(dbBackgroundJobConnection));

builder.Services.AddHangfireServer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
