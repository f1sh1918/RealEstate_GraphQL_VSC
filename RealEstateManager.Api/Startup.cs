
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateManager.Database;
using RealEstateManager.DataAccess.Repositories;
using GraphiQl;

using GraphQL;
using RealEstateManager.Api.Queries;
using RealEstateManager.Types;
using GraphQL.Types;
using RealEstateManager.Api.Schema;

namespace RealEstateManager.Api
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
            services.AddMvc();
            //Add Transient means that this repo will provides to every controller and every services
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();

        }
    }
}
