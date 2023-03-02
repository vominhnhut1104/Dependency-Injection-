using DISample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IProductService, BetterProductService>();
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

app.UseMvc(routes =>
{
    //routes.MapRoute("secure", "secure", new
    //{
    //    Controller = "Admin",
    //    Action = "Index"
    //});

    //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
