using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ThePackage.Models.Database;
using ThePackage.Models.Entities;
using ThePackage.Services;
using ThePackage.Services.Interfaces;

namespace ThePackage
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
            services.AddDbContext<PackageDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SQLConnectionString")
                    )
            );

            services.AddTransient<IService<Client>, ClientService>();
            services.AddTransient<IService<Point>, PointService>();
            services.AddTransient<IService<Staff>, StaffService>();
            services.AddTransient<IService<Units>, ReferencesService>();
            services.AddTransient<IService<PackageType>, PackageTypeService>();
            services.AddTransient<IService<Package>, PackageService>();

            services.AddMvc(options => { options.AllowEmptyInputInBodyModelBinding = true; })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
