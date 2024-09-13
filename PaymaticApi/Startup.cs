/**
* (c)2013-2023 CodeBase SPA Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-09-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Data.CicloTransferencia;
using Cl.Intertrade.ActivPay.Repository.CicloTransferencia;
using Cl.Intertrade.ActivPay.Data.Convenio;
using Cl.Intertrade.ActivPay.Repository.Convenio;
using Cl.Intertrade.ActivPay.Data.DetalleFactura;
using Cl.Intertrade.ActivPay.Repository.DetalleFactura;
using Cl.Intertrade.ActivPay.Data.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Repository.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Data.Edificio;
using Cl.Intertrade.ActivPay.Repository.Edificio;
using Cl.Intertrade.ActivPay.Data.Factura;
using Cl.Intertrade.ActivPay.Repository.Factura;
using Cl.Intertrade.ActivPay.Data.Transferencia;
using Cl.Intertrade.ActivPay.Repository.Transferencia;
using Cl.Intertrade.ActivPay.Data.Usuario;
using Cl.Intertrade.ActivPay.Repository.Usuario;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Cl.Intertrade.ActivPay.Repository.Pago;
using Cl.Intertrade.ActivPay.Data.Pago;
using Cl.Intertrade.ActivPay.ActivPayApi.Data.Dashboard;
using Cl.Intertrade.ActivPayApi.Data.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Repository.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPay.Data.Banco;
using Cl.Intertrade.ActivPay.Data.TipoAbono;
using Cl.Intertrade.ActivPay.Repository.Banco;
using Cl.Intertrade.ActivPay.Repository.TipoAbono;
using Cl.Intertrade.ActivPay.Data.Uf;
using Cl.Intertrade.ActivPay.Repository.Uf;

namespace Cl.Intertrade.ActivPay
{
    public class Startup
    {
        readonly string PermitirSitios = "PermitirSitios";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: PermitirSitios,
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<SettingsConfig>(Configuration.GetSection(nameof(SettingsConfig)));
            services.AddSingleton<ISettingsConfig>(provider => provider.GetRequiredService<IOptions<SettingsConfig>>().Value);
            services.AddSingleton<ICicloTransferenciaService, CicloTransferenciaService>();
            services.AddSingleton<ICicloTransferenciaRepository, CicloTransferenciaRepository>();
            services.AddSingleton<IConvenioService, ConvenioService>();
            services.AddSingleton<IConvenioRepository, ConvenioRepository>();
            services.AddSingleton<IDetalleFacturaService, DetalleFacturaService>();
            services.AddSingleton<IDetalleFacturaRepository, DetalleFacturaRepository>();
            services.AddSingleton<IDetalleTransferenciaService, DetalleTransferenciaService>();
            services.AddSingleton<IDetalleTransferenciaRepository, DetalleTransferenciaRepository>();
            services.AddSingleton<IEdificioService, EdificioService>();
            services.AddSingleton<IEdificioRepository, EdificioRepository>();
            services.AddSingleton<IFacturaService, FacturaService>();
            services.AddSingleton<IFacturaRepository, FacturaRepository>();
            services.AddSingleton<ITransferenciaService, TransferenciaService>();
            services.AddSingleton<ITransferenciaRepository, TransferenciaRepository>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IPagoService, PagoService>();
            services.AddSingleton<IPagoRepository, PagoRepository>();
            services.AddSingleton<IDashboardService, DashboardService>();
            services.AddSingleton<IArchivoPagoProveedoresService, ArchivoPagoProveedoresService>();
            services.AddSingleton<IArchivoPagoProveedoresRepository, ArchivoPagoProveedoresRepository>();
            services.AddSingleton<IBancoService, BancoService>();
            services.AddSingleton<IBancoRepository, BancoRepository>();
            services.AddSingleton<ITipoAbonoService, TipoAbonoService>();
            services.AddSingleton<ITipoAbonoRepository, TipoAbonoRepository>();
            services.AddSingleton<IUfService, UfService>();
            services.AddSingleton<IUfRepository, UfRepository>();

            services.AddControllers()
                   .AddJsonOptions(options =>
                   {
                       options.JsonSerializerOptions.IgnoreNullValues = true;
                   });
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Cl.Intertrade.ActivPay", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Use su token JWT. Ejemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Cl.Intertrade.ActivPay V1");
            });

            app.UseHttpsRedirection();
            //app.UseHttpMethodOverride();

            app.UseRouting();
            app.UseCors(PermitirSitios);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
