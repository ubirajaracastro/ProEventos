using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProEventos.Aplicacao;
using ProEventos.Aplicacao.Contratos;
using ProEventos.Persistencia.Contratos;
using ProEventos.Persistencia.Contexto;
using ProEventos.Persistencia;

namespace ProEventos.Api
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
          services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
             
          services.AddScoped<IEventoService, EventoService>();         
          services.AddScoped<IEventoPersistencia, EventoPersistencia>();
          services.AddScoped<IGeralPersistencia, GeralPersistencia>();
                    
          services.AddDbContext<ProEventoContext>(optionns =>
          optionns.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.Api v1"));
            }

            app.UseCors("AllowSpecificOrigin");
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
