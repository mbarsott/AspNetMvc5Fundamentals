using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string uri = "http://localhost:8081";
//
//            using (WebApp.Start<Startup>(uri))
//            {
//                Console.WriteLine("Started!");
//                Console.ReadKey();
//                Console.WriteLine("Stopping!");
//            }
//        }
//    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
//            app.Use(async (environment, next) =>
//            {
//                foreach (var pair in environment.Environment)
//                {
//                    Console.WriteLine($"{pair.Key}: {pair.Value}");
//                }
//
//                await next();
//            });

            app.Use(async (environment, next) =>
            {
                Console.WriteLine($"Requesting : {environment.Request.Path}");
                await next();
                Console.WriteLine($"Response : {environment.Response.StatusCode}");
            });

            ConfigureWebApi(app);
            app.UseHelloWorld();

//            app.Use<HelloWorldComponent>();

            //            app.UseWelcomePage();

            //            app.Run(ctx =>
            //            {
            //                return ctx.Response.WriteAsync("Hello World!");
            //            });
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            app.UseWebApi(config);

        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        //            public HelloWorldComponent(Func<IDictionary<string, object>, Task> next)
        private AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }
        //            public async Task Invoke(IDictionary<string, object> environment)
        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!!");
            }
            //                await _next(environment);
        }
    }
}
