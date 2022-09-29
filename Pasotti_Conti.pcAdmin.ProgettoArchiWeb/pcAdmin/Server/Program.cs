using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using pcAdmin.Server.Controllers;
using pcAdmin.Server.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Necessario per le Migrations
/*
var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
builder.Services.AddDbContext<DataContext>(
 // options => options.UseNpgsql(configuration.GetConnectionString("PostgresSQL")
 // options => options.UseSqlite(configuration.GetConnectionString("Sqlite")
 // options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")
   ));
*/

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
