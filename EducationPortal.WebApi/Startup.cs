using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using EducationPortal.Persistence.Contexts;
using EducationPortal.Persistence.DbRepository;
using EducationPortal.Web.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

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
            services.AddDbContext<EducationPortalDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("EducationPortalDatabase")));

            services.AddSingleton(x => LoggerFactory.Create(builder => builder.AddConsole()));

            services.AddTransient<IUserRepository, UserDbRepository>();
            services.AddTransient<GetPasswordHash>();
            services.AddTransient<IAuthorizeService, AuthorizeService>();


            services.AddTransient<IRepository<Course>, CourseDbRepository>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IRepository<Material>, MaterialDbRepository>();
            services.AddTransient<IMaterialService, MaterialService>();

            services.AddTransient<ICourseResultRepository, CourseResultDbRepository>();
            services.AddTransient<ICourseResultService, CourseResultService>();
            services.AddTransient<Claims>();
            services.AddTransient<TokenManager>();

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationPortal.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = TokenManager.GetValidator();
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
