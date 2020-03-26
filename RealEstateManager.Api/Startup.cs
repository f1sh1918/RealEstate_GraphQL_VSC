
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
using RealEstateManager.Types.Property;
using RealEstateManager.Types.Payment;
using GraphQL.Types;
using RealEstateManager.Api.Schema;
using RealEstateManager.DataAccess.Repositories.Contracts;

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
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            //Add Db Context with valid ConnectionString
            services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            //Add Document Executer
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            //Add Queries
            services.AddSingleton<PropertyQuery>();
            //Add Types
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PaymentType>();
            var sp = services.BuildServiceProvider();
            //Add Schema
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
