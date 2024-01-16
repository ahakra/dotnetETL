using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DataSource.BackgroundServices;
using DataSource.BackgroundServices.Entities;
using DataSource.Entities;
using DataSource.Extnesions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Grpc.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.Configure<DatasourceDatabaseSettings>(
    builder.Configuration.GetSection("DatasourcestoreDatabase"));

builder.Services.Configure<DataSourceManagerInitializer>(
    builder.Configuration.GetSection("DataSourceManagerIntializer"));

builder.Services.AddHostedService<DatasourceManagerBackgroundService>();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;

}).AddApplicationPart(typeof(DataSource.Api.AssemblyReference).Assembly);
var app  = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

