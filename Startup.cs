using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using workOrderAPI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;


namespace workOrderAPI
{
    public class Startup
    {

    public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();// removed /added var
            }
      public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<WorkOrderContext>(opt => opt.UseInMemoryDatabase("WorkOrderList"));
            services.AddEntityFrameworkInMemoryDatabase()
              .AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("WorkOrderList")); //maybe change to userList

            services.AddIdentity<ApplicationUser, ApplicationRole>() //maybe be a model of user, role
              .AddEntityFrameworkStores<UserDbContext>();

            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            
            services.AddDbContext<WorkOrderContext>(opt => 
                opt.UseInMemoryDatabase("WorkOrderList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
             // Register the Swagger generator, defining 1 or more Swagger documents
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info{
                    Version = "v1",
                    Title = "Work Order API",
                    Description = "Implementation of the work order API using ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact{
                        Name =  string.Empty,
                        Email = String.Empty,
                        Url = string.Empty
                    },
                    License = new License{
                        Name = string.Empty,
                        Url = string.Empty
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>{
                o.TokenValidationParameters = new TokenValidationParameters{
                     ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddMvc();
                    
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger(o => {
                o.RouteTemplate = "api-docs/{documentName}/api-docs.json";
            });
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint("/api-docs/v1/api-docs.json", "Work Order API V1");
                c.RoutePrefix = "api-docs";
            });                           
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
