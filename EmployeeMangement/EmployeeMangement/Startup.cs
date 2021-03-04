using EmployeeMangement.Dbcontexts;

using EmployeeMangement.Models.Employee;
using EmployeeMangement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeMangement
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication()
                  //.AddGoogle(googleOptions => {
                  //  // Đọc thông tin Authentication:Google từ appsettings.json
                  //  IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                  //  // Thiết lập ClientID và ClientSecret để truy cập API google
                  //  googleOptions.ClientId = googleAuthNSection["ClientId"];
                  //    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                  //  // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                  //  googleOptions.CallbackPath = "/dang-nhap-tu-google";

                  //})
                  //.AddFacebook(facebookOptions => {
                  //    // Đọc cấu hình
                  //    //IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication: Facebook");
                  //    //facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                  //  // Thiết lập đường dẫn Facebook chuyển hướng đến
                  //  facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
                  //});
            services.AddMvc(option => option.EnableEndpointRouting = false);
            // dung de su dung autherize
            //Single authorization policy used globally
            //services.AddMvc(o =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    o.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddSingleton<IEmployeeService, MockEmployeeService>();
            services.AddScoped<IEmployeeService, SqpEmployeeSevices>();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("DbConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Erorr");
                // dung de hien ra loi khi tu mo controler
                // ddi vao trang erorr/404

                //app.UseStatusCodePagesWithRedirects("/Erorr/{0}");
                // hieen ra url chuw ko vao mac dinh erorr
                app.UseStatusCodePagesWithReExecute("/Erorr/{0}");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routers =>
            {
                routers.MapRoute(
                        name: "default",
                        template: "{controller=Employee}/{action=Index}/{id?}"
                    );
                routers.MapRoute(
                        name: "2ndRouting",
                        template: "{controller=Home}/{action=Login}/{un}/{pw}"
                    );

            });


        }
    }
}
