using mscs.Services;
using mscs.Data;
using mscs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();

// builder.Services.Add(new ServiceDescriptor(typeof(DataBaseDeviceService), new
// DataBaseDeviceService(Configuration.GetConnectionString("MySqlConnectionString"))));
builder.Services.AddTransient<DataBaseDeviceService>();
builder.Services.AddControllers();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

var DevicesConnectionString =
    builder.Configuration.GetConnectionString("MySqlConnectionString");
var IdentityConnectionString =
    builder.Configuration.GetConnectionString("IdentityConnectionString");

builder.Services.AddDbContext<MscsContext>(
    options =>
        options.UseMySql(DevicesConnectionString,
                         ServerVersion.AutoDetect(DevicesConnectionString)));
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseMySql(IdentityConnectionString,
                         ServerVersion.AutoDetect(IdentityConnectionString)));

builder.Services.AddIdentityCore<MyUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();
var app = builder.Build();
app.MapIdentityApi<MyUser>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for
  // production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();
// lame method to add endpoints
// app.MapGet("/devices", (context)=>{
//     return context.Response.WriteAsync("List of Devices");
// });

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
