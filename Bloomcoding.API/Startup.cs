using Bloomcoding.API.Infrastructure.Extensions;
using Bloomcoding.API.Infrastructure.Middlewares;
using Bloomcoding.Bll;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Bll.Services;
using Bloomcoding.Dal;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Dal.Repositories;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Bloomcoding.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BloomcodingDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("BloomcodingConnection"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<BloomcodingDbContext>();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);

            services.AddControllers();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IHomeworkRepository, HomeworkRepository>();

            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IHomeworkService, HomeworkService>();
            services.AddScoped<IUserGroupService, UserGroupService>();

            services.AddAutoMapper(typeof(BllAssemblyMarker));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bloomcoding.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(o =>
                {
                    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
                //app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bloomcoding.API v1"));
            }
            else
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
            }
               
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/asdfg", async context => { await context.Response.WriteAsync("what are you doing here?"); });
                endpoints.MapControllers();
            });
        }
    }
}
