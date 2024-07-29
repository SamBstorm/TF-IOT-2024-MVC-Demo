namespace Exo01_Routing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name : "accueil",
                pattern : "Accueil",
                defaults : new { controller = "Home", action = "Index"}
                );

            app.MapControllerRoute(
                name: "HomeReglementations",
                pattern: "Home/Reglementations",
                defaults : new { controller = "Home", action = "Privacy"});

            app.MapControllerRoute(
                name: "reglementations",
                pattern: "Reglementations",
                defaults: new { controller = "Home", action = "Privacy" });

            app.MapControllerRoute(
                name : "rules",
                pattern : "Rules",
                defaults : new { controller = "Home", action = "Privacy"}
                );

            app.MapControllerRoute(
                name: "ncage",
                pattern: "Math",
                defaults: new { Controller = "Math", Action = "Index" }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
