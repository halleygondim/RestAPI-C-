using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RestAPI.Models.Context;
using RestAPI.Repositories;
using RestAPI.Repositories.Generic;
using RestAPI.Security.Configuration;
using RestAPI.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

    

     
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration["OracleConnection:OracleConnectionString"];
            services.AddDbContext<OracleContext>(options => options.UseLazyLoadingProxies().UseOracle(connectionString, opt => opt.UseOracleSQLCompatibility("11")));

            //DEIXAR ROTAS LOWERCASE
            services.AddRouting(options => options.LowercaseUrls = true);

            //QUANDO FOR USAR MIGRATIONS
            //MigrateDatabase(connectionString);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            //CONFIGURAÇÃO JWT
            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                //VALIDA A ASSINATURA
                paramsValidation.ValidateIssuerSigningKey = true;

                //VERIFICA SE O TOKEN É VÁLIDO
                paramsValidation.ValidateLifetime = true;

                // PARAMETRIZAÇÃO DE VERIFICAÇÃO DE TEMPO DE EXPIRAÇÃO DO TOKEN
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // AUTORIZA O USUÁRIO A TER ACESSO AOS RECURSOS
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //CONFIGURAÇÃO PARA TER ACESSO A XML E JSON
            /*
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();
            */

            //QUANDO FOR IMPLEMENTAR O HATEOAS 
            var filterOptions = new HyperMediaFilterOptions();
            // filterOptions.ObjectContentResponseEnricherList.Add(new ProprietarioEnricher());


            //INSTANCIAÇÃO
            services.AddSingleton(filterOptions);

            //VERSIONAMENTO
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //ADICIONANDO SUPORTE AO SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "RESTful API's with ASP.NET",
                        Version = "v1"
                    });

            });
            
            //INJEÇÃO DE DEPENDÊNCIA NAS CLASSES QUE IREMOS USAR NO SISTEMA.

            services.AddScoped<ProprietarioService, ProprietarioServiceImpl>();
            services.AddScoped<VeiculoService, VeiculoServiceImpl>();
            services.AddScoped<AcessorioService, AcessorioServiceImpl>();
            services.AddScoped<AcessorioVeiculoService, AcessorioVeiculoServiceImpl>();
            services.AddScoped<AcessorioVeiculoRepository, AcessorioVeiculoRepositoryImpl>();

            services.AddScoped<ILoginBusiness, LoginBusinessImpl>();
            services.AddScoped<IFileBusiness, FileBusinessImpl>();

            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


            services.AddControllers();
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //INICIALIZA A PÁGINA DO SWAGGER COM A DOCUMENTAÇÃO
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=Values}/{id?}");
            });
        }


        /* QUANDO FOMOS USAR A MIGRAÇÃO
       private void MigrateDatabase(string connectionString)
       {
           try
           {
               var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

               var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
               {
                   Locations = new List<string> { "db/migrations", "db/dataset" },
                   IsEraseDisabled = true,
               };
               evolve.Migrate();

           }
           catch (Exception ex)
           {
               Log.Error("Database migration failed.", ex);
               throw;
           }
       }
       */
    }
}
