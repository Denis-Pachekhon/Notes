using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotesBlazorApp.Data.DB;
using NotesBlazorApp.Data.Repositories;
using NotesBlazorApp.Data.Repositories.Abstract;
using NotesBlazorApp.Domain.Servises;
using NotesBlazorApp.Domain.Servises.Abstract;

namespace NotesBlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddAutoMapper(
                typeof(NotesBlazorApp.Domain.Profiles.NoteProfile),
                 typeof(NotesBlazorApp.Profiles.NoteProfile));

            services.AddDbContext<NoteBlazorAppDbContext>(options =>
            {
                options
                .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                assembly => 
                assembly.MigrationsAssembly("NotesBlazorApp.Data"));
            });

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteService, NoteService>();
        }

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
