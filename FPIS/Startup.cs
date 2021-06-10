using FluentValidation.AspNetCore;
using FPIS.DataAccess;
using FPIS.DataAccess.Repositories.Implementations;
using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Service.Implementations;
using FPIS.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(Configuration["ConnectionStrings:fpis"]);
        });

        services.AddAutoMapper(typeof(Startup));

        services.AddSwaggerGen();

        services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        //services.AddOpenApiDocument();
        services.AddControllers();

        services.AddTransient<IDobavljacRepository, DobavljacRepository>();
        services.AddTransient<IDobavljacService, DobavljacService>();

        services.AddTransient<IUlaznaFakturaRepository, UlaznaFakturaRepository>();
        services.AddTransient<IUlaznaFakturaService, UlaznaFakturaService>();

        services.AddTransient<IStavkaUlazneFaktureRepository, StavkaUlazneFaktureRepository>();
        services.AddTransient<IStavkaUlazneFaktureService, StavkaUlazneFaktureService>();

        services.AddAutoMapper(typeof(Startup));
        services.AddMvc().AddFluentValidation();
        services.AddMvc(option => option.EnableEndpointRouting = false)
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("MyPolicy");

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseSwagger();

        app.UseStaticFiles();

        UpdateDatabase(app);

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static void UpdateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
        context.Database.Migrate();
    }
}