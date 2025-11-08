using FuelManagement.Core.Services.Interface;
using FuelManagement.Core.Services;
using FuelManagement.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRulesService, RulesService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();


builder.Services.AddDbContext<FuelmanagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FuelmanagementConnection"));
});


#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:6974")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
#endregion
var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
// خطایابی بهتر در محیط توسعه
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//ترتیب Middleware‌ها (خیلی مهم)
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// CORS باید قبل از Authentication باشه
app.UseCors("MyPolicy");
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

