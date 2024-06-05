using EmailApp.Data;
using EmailApp.Models;
using EmailApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
{
    throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'.");
}
builder.Services.AddDbContext<EmailDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    //.WriteTo.File("C:\\Logs\\EmailApp.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
