using Composifit.Core;
using Composifit.Domain;
using Composifit.Domain.ServiceContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Composifit.Extensions;

namespace Composifit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.Audience = "6fqkgms51esvhk8oq56iqneg79";
                options.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_qaSHy4NW0";
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(AutoMaps));
            services.AddDbContext<ComposifitDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityProvider>(x => new IdentityProvider(x.GetService<IHttpContextAccessor>().HttpContext.User.GetUsername()));
            services.AddTransient<IMesoService, MesoService>();
            services.AddTransient<ITrackService, TrackService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<ICardioService, CardioService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=ValuesController}/{action=Get}/{id?}");
            });
        }
    }
}
