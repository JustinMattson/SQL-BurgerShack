using System.Data;
using BurgerShack.Repositories;
using BurgerShack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;

namespace BurgerShack
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
      // Add USER AUTH THROUGH JWT - 7/15
      // Requires - 7/15 => dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
        options.Audience = Configuration["Auth0:Audience"];
      });

      // NOTE Cors Serviced required for Auth0 - 7/15
      services.AddCors(options =>
      {
        options.AddPolicy("CorsDevPolicy", builder =>
          {
            builder
              .WithOrigins(new string[] { "http://localhost:8080", "http://localhost:8081" })
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
          });
      });

      // Controllers
      services.AddControllers();

      // NOTE create scoped connection to DB
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      // Services
      services.AddTransient<BurgerService>();
      services.AddTransient<SideService>();
      services.AddTransient<ComboService>();

      // Repositories
      services.AddTransient<BurgerRepository>();
      services.AddTransient<SideRepository>();
      services.AddTransient<ComboRepository>();
    }

    // Creates and returns connection to DB
    private IDbConnection CreateDbConnection()
    {
      string connectionSTring = Configuration.GetSection("db").GetValue<string>("gearhost");
      return new MySqlConnection(connectionSTring);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // app.UseCors("CorsDevPolicy"); added 7/15 with Auth0
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      // app.UseAuthentication(); added 7/15 with Auth0
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
