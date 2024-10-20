using System;
using System.IO;
using System.Runtime.InteropServices;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FORMULARIOCENSI.Data;

public class Program
{
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern IntPtr LoadLibrary(string lpFileName);
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string dllDirectory = Path.Combine(Directory.GetCurrentDirectory(), "lib");
        LoadLibrary(Path.Combine(dllDirectory, "libwkhtmltox.dll"));

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgressConnection")));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Identity/Account/Login"; // Cambia esta ruta a la tuya
            options.AccessDeniedPath = "/Account/AccessDenied"; // Ruta opcional para acceso denegado
        });

        builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        // Configure the HTTP request pipeline.
        var app = builder.Build();

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}
