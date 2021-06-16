using BookA.Data;
using BookA.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //services.AddDbContext<BookSpec>(options => options.UseSqlServer());
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer());
            
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<StudentRepository, StudentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Use(async(context, next)=>
            //    {
            //        await context.Response.WriteAsync("Hello from 1st middleware");
            //        await next();
            //        await context.Response.WriteAsync("Hello from 2nd middleware");
            //        await next();
            //        await context.Response.WriteAsync("Hello from 3rd middleware");
            //    });
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
            });
            
        }
    }
}
