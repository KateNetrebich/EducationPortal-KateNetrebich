using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using EducationPortal.Persistence.Contexts;
using EducationPortal.Persistence.DbRepository;
using EducationPortal.Web.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationPortalDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("EducationPortalDatabase")));

            services.AddSingleton(x => LoggerFactory.Create(builder => builder.AddConsole()));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/SignIn");
               });

            services.AddTransient<IUserRepository, UserDbRepository>();
            services.AddTransient<GetPasswordHash>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<IRepository<Course>, CourseDbRepository>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IRepository<Material>, MaterialDbRepository>();
            services.AddTransient<IMaterialService, MaterialService>();

            services.AddTransient<ICourseResultRepository, CourseResultDbRepository>();
            services.AddTransient<ICourseResultService, CourseResultService>();
            services.AddTransient<Claims>();

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
