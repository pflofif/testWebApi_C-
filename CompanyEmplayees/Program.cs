using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), @"\nlog.config"));

builder.Services.AddScoped<ILoggerManager, LoggerManager>();

builder.Services.AddDbContext<RepositoryContext>(
    opts => opts.UseSqlServer(
        builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("CompanyEmplayees")
    )
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.Configure<IISOptions>(_ => { });
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
//app.UseRouting();
app.UseAuthorization();

app.MapControllers();


app.Run();
