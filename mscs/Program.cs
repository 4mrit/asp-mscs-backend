using mscs.Services;
using mscs.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Services.Add(new ServiceDescriptor(typeof(DataBaseDeviceService), new DataBaseDeviceService(Configuration.GetConnectionString("MySqlConnectionString"))));
builder.Services.AddTransient<DataBaseDeviceService>();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
builder.Services.AddDbContext<MscsContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();
// lame method to add endpoints
// app.MapGet("/devices", (context)=>{
//     return context.Response.WriteAsync("List of Devices");
// });

app.Run();
