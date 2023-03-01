using ECommerce.Application.Extensions;
using ECommerce.Application.ServiceBus;
using ECommerce.Application.Services;
using ECommerce.Application.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.Routing.Template;

namespace SampleECommerceWebApplication
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
            services.AddRazorPages();
            services.AddSwaggerGen();
            services.AddControllers();
            services.ConfigureMySqlContext(Configuration);
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ServiceBusSender>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages(); //Routes for pages
            //    endpoints.MapControllers(); //Routes for my API controllers
            //});
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
