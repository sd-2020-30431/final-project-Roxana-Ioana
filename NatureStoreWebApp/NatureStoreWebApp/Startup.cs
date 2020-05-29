using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NatureStoreWebApp.Model;
using NatureStoreWebApp.Repositories;
using Microsoft.AspNetCore.Identity;

namespace NatureStoreWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //services
        public void ConfigureServices(IServiceCollection services)
        {
            //adds db context to the container
            //database context will use an in-memory database
            services.AddDbContext<ProductContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddControllers();
            services.AddCors();
            services.AddTransient<IProductRepository, ProductRepository>();
            //el a pus AddDefaultIdentity
            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ProductContext>();
            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAuthentication();
        }
    }
}
