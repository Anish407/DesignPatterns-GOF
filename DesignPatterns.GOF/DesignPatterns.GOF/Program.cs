using Bridge;
using Bridge.Enum;
using Bridge.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DesignPatterns.GOF
{
    class Program
    {
        static void Main(string[] args)
        {
            IRectangle obj = serviceProvider.GetRequiredService<Rectangle>();
            obj.Draw(DrawApiType.OpenGL);
            Console.ReadLine();
           // obj.DrawType(DrawApiType.SVG);
        }

        public static IServiceProvider serviceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<OpenGlDraw>();
            services.AddScoped<SvgDrawApi>();
            services.AddScoped<MsPaint>();

            services.AddScoped<IRectangle, Rectangle>();
            services.AddScoped<Square>();




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

            serviceProvider = services.BuildServiceProvider();

        }
    }
}
