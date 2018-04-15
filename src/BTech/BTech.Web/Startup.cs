using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTech.DataAccess.Context;
using BTech.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BTech.Web
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
			var signinConfigurations = new SigningConfigurations();
			services.AddSingleton(signinConfigurations);

			var tokenConfigurations = new TokenConfiguration();
			new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
			services.AddSingleton(tokenConfigurations);

			services.AddAuthentication(authOptions =>
			{
				authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(bearerOptions =>
			{
				var paramsValidation = bearerOptions.TokenValidationParameters;
				paramsValidation.IssuerSigningKey = signinConfigurations.Key;
				paramsValidation.ValidAudience = tokenConfigurations.Audience;
				paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

				paramsValidation.ValidateIssuerSigningKey = true;
				paramsValidation.ValidateLifetime = true;
				paramsValidation.ClockSkew = TimeSpan.Zero;
			});

			services.AddAuthorization(auth =>
			{
				auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
						.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
						.RequireAuthenticatedUser().Build());
			});

			

			services.AddDbContext<BTContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			BTContext context = serviceProvider.GetService<BTContext>();
			MockData.AddMockData(context);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
