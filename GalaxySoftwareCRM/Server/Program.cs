
using GalaxySoftwareCRM.Server.DataAccess;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


/*Added For CORS stands for cross-origin resource sharing
 * more ref: here 
 * https://www.syncfusion.com/faq/blazor/general/how-do-you-enable-cors-in-a-blazor-server-application
 */
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomCorsPolicy", builder =>
     builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});


DbHelper.SqlConnectionString = builder.Configuration.GetConnectionString("DbConnection");

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

app.UseHttpsRedirection();

app.UseCors("CustomCorsPolicy");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
