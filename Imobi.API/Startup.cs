
using Imobi.Business.BusinessConcretas;
using Imobi.Business.GerenciamentoImovel;
using Imobi.Business.GerenciamentoUsuario;
using Imobi.Business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Imobi.API
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

            services.AddTransient<ICidadeBusiness, CidadeBusiness>()
                    .AddTransient<IEstadoBusiness, EstadoBusiness>()
                    .AddTransient<IBairroBusiness, BairroBusiness>()
                    .AddTransient<IEnderecoBusiness, EnderecoBusiness>()
                    .AddTransient<IPerfilBusiness, PerfilBusiness>()
                    .AddTransient<ITipoImovelBusiness, TipoImovelBusiness>()
                    .AddTransient<IFormaDePagamentoBusiness, FormaDePagamentoBusiness>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Imobi.API", Version = "v1" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imobi.API v1"));
            
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
