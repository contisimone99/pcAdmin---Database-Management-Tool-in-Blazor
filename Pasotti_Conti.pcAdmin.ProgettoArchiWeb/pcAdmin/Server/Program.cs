using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using pcAdmin.Server.Controllers;
using pcAdmin.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var provider = DbProvider.SQLServer;
var connectionString = ConnectionStrings.Get(provider);

/* var options = new DbContextOptionsBuilder<DataContext>()
    .Use(provider, connectionString)
    .Options;
*/

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);

});

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
