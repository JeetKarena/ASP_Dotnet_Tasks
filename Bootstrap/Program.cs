var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
/*  State Area Route    */
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=State}/{action=Index}/{id?}"
    );
});

/*  City Area Route  */
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=City}/{action=Index}/{id?}"
    );
});
/*  Country Route   */
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Country}/{action=Index}/{id?}");
/* Branch Route*/
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Branch}/{action=Index}/{id?}"
    );
});

/* Student Route */
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Student}/{action=Index}/{id?}"
    );
});

/* Wildcard Route */
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "wildcard",
        pattern: "{*url}",
        defaults: new { controller = "Wildcard", action = "Index" }
    );
});
app.Run();