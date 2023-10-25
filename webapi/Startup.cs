using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Business;
using webapi.Data;

public class Startup
{
    public Startup(IConfiguration configuration) { 
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataProtection();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDistributedMemoryCache(); 
        services.AddDbContext<SqlServerContext>(
            options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
        });

        services.AddSession();

        //Repository
        services.AddTransient<ClientRepository>();
        services.AddTransient<ClientServices>();
        services.AddTransient<ItemRepository>();

        services.AddTransient<ItemServices>();
        services.AddTransient<StoreRepository>();

        services.AddTransient<StoreServices>();

        //services




    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x=> x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
        app.UseAuthorization();
        app.UseAuthentication();


        app.UseEndpoints(endpoints => endpoints.MapControllers());
        app.UseSwagger(c =>
        {
            c.SerializeAsV2 = true;
        });

        app.UseSession();
        

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopTest");
        });
        string url = Configuration.GetSection("AppConfiguration").GetSection("UrlFront").Value;
        app.UseCors(
            options => options.WithOrigins(url).AllowAnyMethod()
        ) ;
    }
}