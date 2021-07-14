using EducationPortal.Application.Repositories;
using EducationPortal.Application.Service;
using EducationPortal.Persistence.Contexts;
using EducationPortal.Persistence.DbRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            services.AddTransient<IUserRepository, UserDbRepository>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<ICourseRepository, CourseDbRepository>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<IMaterialRepository, MaterialDbRepository>();
            services.AddTransient<IMaterialService, MaterialService>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
