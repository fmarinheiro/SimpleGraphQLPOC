using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;
using SuperSimpleGraphQLTutorial.Data;
using SuperSimpleGraphQLTutorial.GraphQL.Types;
using SuperSimpleGraphQLTutorial.GraphQL;

namespace SuperSimpleGraphQLTutorial
{
    public abstract class AppConfiguration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ITimeLogRepository, TimeLogRepository>();

            builder.Services.AddDbContext<SuperSimpleGraphQLTutorialContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("SuperSimpleGraphQLTutorialContext") ?? throw new InvalidOperationException("Connection string 'SuperSimpleGraphQLTutorialContext' not found.")
                    ));

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<ProjectType>()
                .AddMutationType<Mutation>();

        }

        public static void ConfigureRequestPipeline(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAuthorization();

            app.MapRazorPages();
           
            app.MapGraphQL();
        }
    }
}
