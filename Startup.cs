using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace testdnslinuxpatob2022
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            TestDns();
            Configuration = configuration;
            }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        //test ip
       // TestDns();
        private void TestDns()
        {
           // try
            {
                var client = new HttpClient();
                var endpoints = new[] { "https://google.com/", "https://youtube.com/" };
                var tasks = endpoints.Select(endpoint => Task.Run(async () => await client.GetAsync(endpoint)));
                Task.WhenAll(tasks).GetAwaiter().GetResult();
            }
         /*   catch (Exception z)
            {
                System.Threading.Thread.Sleep(20000);
            }
            
            */
              //  return true;

           // return false;
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
