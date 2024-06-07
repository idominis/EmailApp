using EmailApp.Data;
using EmailApp.Models;
using EmailApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Text.Json;

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

app.UseSerilogRequestLogging();

// Custom error handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An unhandled exception occurred.");

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var response = new { error = "An unexpected error occurred. Please try again later.", details = ex.Message };
        var json = JsonSerializer.Serialize(response);

        // Set a custom header to indicate that an error occurred
        context.Response.Headers["X-Error"] = "true";
        context.Response.Headers["X-Error-Content"] = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));

        await context.Response.WriteAsync(json);
    }
});








app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
