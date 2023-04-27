using Microsoft.EntityFrameworkCore;
using Database.Context;

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.WebHost.UseConfiguration(configBuilder);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// string test = builder.Configuration["AppSettings:Ambiente"].ToString();

builder.Services.AddDbContext<CVTrackerContext>(op => {
    op.UseInMemoryDatabase(databaseName: "cvtrackerDB");
    //op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });
// builder.WebHost.UseKestrel(serOp => {
//     serOp.ListenAnyIP(6001);
//     serOp.ListenAnyIP(6000, config => config.UseHttps());
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()){
    var dbContext = scope.ServiceProvider.GetRequiredService<CVTrackerContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
