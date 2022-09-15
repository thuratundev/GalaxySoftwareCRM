
using GalaxySoftwareCRM.Server.DataAccess;
using GalaxySoftwareCRM.Server.JwtUtilities;
using GalaxySoftwareCRM.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    // Identity made Cookie authentication the default.
    // However, we want JWT Bearer Auth to be the default.
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();



builder.Services.AddScoped<IJwtUtilities, JwtUtilities>();
builder.Services.AddScoped<IUserService, UserService>();





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




/*Configure the HTTP request pipeline. */
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
app.UseMiddleware<JwtMiddleware>();





app.MapRazorPages();



app.MapControllers();




app.MapFallbackToFile("index.html");

app.Run();

