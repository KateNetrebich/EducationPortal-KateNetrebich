using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using EducationPortal.Persistence.Contexts;
using EducationPortal.Persistence.DbRepository;
using EducationPortal.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EducationPortal.WebApi
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                 .AllowAnyHeader());
            });
            services.AddDbContext<EducationPortalDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("EducationPortalDatabase")));

            services.AddSingleton(x => LoggerFactory.Create(builder => builder.AddConsole()));

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

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationPortal.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EducationPortal.WebApi v1"));
            }

            app.UseHttpsRedirection();

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
