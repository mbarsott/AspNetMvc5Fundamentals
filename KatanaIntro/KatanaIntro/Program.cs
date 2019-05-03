using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8081";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHelloWorld();

//            app.Use<HelloWorldComponent>();

            //            app.UseWelcomePage();

            //            app.Run(ctx =>
            //            {
            //                return ctx.Response.WriteAsync("Hello World!");
            //            });
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
