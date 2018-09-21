using AutoMapper;
using CS.Eventos.IO.Infra.CrossCutting.Bus;
using CS.Eventos.IO.Infra.CrossCutting.Identity.Data;
using CS.Eventos.IO.Infra.CrossCutting.IoC;
using CS.Eventos.IO.Services.Api.Configurarions;
using CS.Eventos.IO.Services.Api.Configurations;
using CS.Eventos.IO.Services.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS.Eventos.IO.Services.Api
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
            // Contexto do EF para o Identity
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configurações de Autenticação, Autorização e JWT.
            services.AddMvcSecurity(Configuration);

            services.AddAuthentication();

            services.AddOptions();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/{version}"));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Version = "v1",
                    Title = "Eventos.IO.API",
                    Description = "API do site Eventos.IO",
                    TermsOfService = "Nenhum",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact() { Name = "Caio", Email = "dsad@eventos.io" },
                    License = new Swashbuckle.AspNetCore.Swagger.License() { Name = "MIT", Url = "mit.com" }
                });
            });

            //services.AddApiVersioning(opts =>
            //{
            //    opts.ApiVersionReader = new 
            //    "api/v{version}"
            //    });

            //REGISTRAR TODAS AS IOC
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, IHttpContextAccessor contextAccessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();

            //O CORS SEVER SOMENTE PARA OUTROS DOMINIOS, POR DEFAULT ELA JA VEM DESABILITADO
            //a aplicação só aceita request de determinados sites, verbos
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
                //c.WithOrigins("www.teste.com.br") sistema só aceita request destas origens
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            logger.AddConsole(Configuration.GetSection("Logging"));
            logger.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Eventos.IO.API V1.0");
            });

            InMemoryBus.ContainerAccessor = () => contextAccessor.HttpContext.RequestServices;

            app.UseSwaggerAuthorized();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
