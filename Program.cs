using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FORMULARIOCENSI.Data;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgressConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// Configuración del Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; // Página de inicio de sesión
    options.LogoutPath = "/Identity/Account/Logout"; // Página de logout (se manejará automáticamente)
    options.AccessDeniedPath = "/Account/AccessDenied"; // Página de acceso denegado
    options.ReturnUrlParameter = "ReturnUrl"; // Parámetro de retorno

    options.Events.OnRedirectToLogin = async context =>
    {
        // Si el usuario está autenticado, redirigir dependiendo del rol
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.GetUserAsync(context.HttpContext.User);
            var roles = await userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                context.Response.Redirect("/Admin/Index"); // Redirige a Admin/Index si es Admin
            }
            else
            {
                context.Response.Redirect("/Formulario/Index2"); // Redirige a Formulario/Index2 si es User
            }
        }
        else
        {
            // Si el usuario no está autenticado, redirige al login
            context.Response.Redirect("/Identity/Account/Login?message=loggedOut");
        }

        await Task.CompletedTask;
    };
});


var app = builder.Build();

// Configurar el pipeline de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin", action = "Index" });

app.MapControllerRoute(
    name: "user",
    pattern: "Formulario/{action=Index2}/{id?}",
    defaults: new { controller = "Formulario", action = "Index2" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index2}/{id?}");

// Rutas de Razor Pages para Identity
app.MapRazorPages();

app.MapGet("/", context =>
{
    // Redirige a la página de login si no está autenticado
    context.Response.Redirect("/Identity/Account/Login");
    return Task.CompletedTask;
});

app.Run();
