using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloASP
{
    //configure services is where you add your services to your project
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        //We can accpet the object from anythere, we just need to accept the object

         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(options => options.EnableEndpointRouting = false);  //add this line    
        }
            
        //It going trun, wait for a localhost connection, and then run hello world     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {        
            // some code removed for brevity    
            app.UseStaticFiles();    
            app.UseMvc();    //add this line, replacing the app.UseRouting() and app.UseEndpoints() lines of code    
        }
    }
}

//Notes
//public static void ConfigureServices(IServiceCollection services)
// {    
//     services.AddMvc(options => options.EnableEndpointRouting = false);
// }

//We are adding a service ntour application Service Container, seen here as IServiceCollection
//This makes the specified service availabe to rest of the application
//In this example, we are saying our app wants to make use framework MVC service, which is handled internally by the framework itself to make the whole things go
//with OOP

//Dependency Injection
//You can use any type of DI, called COnstruction Injection, to bring any service
//to bring any service into your class by accepting the object of the desired service type into the constructor method of that class

// public class Startup {        
//     // other code in Startup        
//     public Startup(IWebHostEnvironment env) {            
//         // run this in the debugger, and inspect the "env" object! You can use this object to tell you 
//         // the root path of your application, for the purposes of reading from local files, and for            
//         // checking environment variables - such as if you are running in Development or Production 
//         Console.WriteLine(env.ContentRootPath);            
//         Console.WriteLine(env.IsDevelopment());
//     }
// }

//We will be working with a frameservice calledIhostingEnvironemnt, which is an object 
//that will tell you more about the machine that is hosting the application
//While in devlopment, this will be local pc, when you deploy this will be a remote web server

//We are listening for a particular request, at a particular url and when we when that request is recieved from our controller class, a response is provided