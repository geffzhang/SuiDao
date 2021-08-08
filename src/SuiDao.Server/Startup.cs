﻿using FastTunnel.Core;
using FastTunnel.Core.Handlers.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuiDao.Server.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiDao.Server
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
            // -------------------FastTunnel START------------------
            services.AddFastTunnelServer(Configuration.GetSection("ServerSettings"));
            // -------------------FastTunnel END--------------------

            services.AddSingleton<ILoginHandler, SuiDaoLoginHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }

            // -------------------FastTunnel START------------------
            app.UseFastTunnelServer();
            // -------------------FastTunnel END--------------------

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
                //endpoints.MapControllers();
            });
        }
    }
}
