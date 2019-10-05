using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridge;
using Bridge.Enum;
using Bridge.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Gof.Web
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
            services.AddControllers();
            services.AddScoped<OpenGlDraw>();
            services.AddScoped<SvgDrawApi>();
            services.AddScoped<MsPaint>();

            services.AddScoped<Rectangle>();
            services.AddScoped<Square>();

            services.AddTransient<Func<int, IShape>>(serviceProvider=>shape =>
            {
                return shape switch
                {
                    1 => serviceProvider.GetService<Rectangle>(),
                    2 => serviceProvider.GetService<Square>(),
                    _=> throw new KeyNotFoundException($"Shape not found for {shape}")
                };
            });

            services.AddTransient<Func<DrawApiType, IDrawApi>>(serviceProvider => key =>
            {
                //c# 7
                //switch (key)
                //{
                //    case DrawApiType.OpenGL:
                //        return serviceProvider.GetService<OpenGlDraw>();
                //    case DrawApiType.SVG:
                //        return serviceProvider.GetService<SvgDrawApi>();
                //    case DrawApiType.MsPaint:
                //        return serviceProvider.GetService<MsPaint>();
                //    default:
                //        throw new KeyNotFoundException(); // or maybe return null, up to you
                //}

                //c# 8
                return key switch
                {
                    DrawApiType.OpenGL => serviceProvider.GetService<OpenGlDraw>(),
                    DrawApiType.SVG => serviceProvider.GetService<SvgDrawApi>(),
                    DrawApiType.MsPaint => serviceProvider.GetService<MsPaint>(),
                    _ => throw new KeyNotFoundException($"Could not resolve {nameof(DrawApiType)}")
                };

                //_ = ("aa" switch
                //{
                //    "aa" => "",

                //});
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
