using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTetrisScoreSystem.Areas.Administration.Services;
using WebTetrisScoreSystem.Data;
using WebTetrisScoreSystem.Hubs;
using WebTetrisScoreSystem.Services;

namespace WebTetrisScoreSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private RoleManager<IdentityRole> roleManager;

        private UserManager<Player> userManager;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DbConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<Player>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<Player>>()
                .AddUserManager<UserManager<Player>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddSignalR();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.AddScoped<ApplicationDbContext>();

            services.AddTransient<ITetrisService, TetrisService>();
            services.AddTransient<IAdminService, AdminService>();

        }

        private async Task CreateAdminWithRole(IServiceProvider serviceProvider)
        {
            roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = serviceProvider.GetRequiredService<UserManager<Player>>();

            var roleExists = await roleManager.RoleExistsAsync("Admin");
            var userExists = await userManager.FindByNameAsync("admin77");

            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
            }

            if (userExists == null)
            {
                var user = new Player();
                user.UserName = "admin77";
                string password = "654321";

                var userResult = await userManager.CreateAsync(user, password);

                if (userResult.Succeeded)
                {
                    var result = await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chathub");
            });

            CreateAdminWithRole(serviceProvider).Wait();
        }
    }
}
