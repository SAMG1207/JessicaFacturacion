
using JessicaFacturacion.Config;
using JessicaFacturacion.Data;
using JessicaFacturacion.Mappers;
using JessicaFacturacion.Middlewares;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.Cliente;
using JessicaFacturacion.Repository.GenericRepository;
using JessicaFacturacion.Repository.GenericRepository.Interface;
using JessicaFacturacion.Repository.Jessica;
using JessicaFacturacion.Repository.Logger;
using JessicaFacturacion.Repository.PacienteRepository;
using JessicaFacturacion.Repository.TipoDeFacturacionRepository;
using JessicaFacturacion.Services.ClienteService;
using JessicaFacturacion.Services.JessicaService;
using JessicaFacturacion.Services.PacienteService;
using JessicaFacturacion.Services.TiposDeFacturacionService;
using JessicaFacturacion.Utils.Passwords;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace JessicaFacturacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            builder.Services.Configure<Config.SessionSettings>(builder.Configuration.GetSection("SessionSettings"));

            builder.Services.AddScoped<PasswordHasher<object>>(); // Usado para el hash de contraseñas
            builder.Services.AddScoped<PasswordManager>();
            
        

            //Mappers

            builder.Services.AddAutoMapper(typeof(ClienteProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(PacienteProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(CitaProfile).Assembly);
            // Add services to the container.  
            builder.Services.AddControllersWithViews();

            // Configuración de servicios  
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            // INYECCIONES  
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Inyecciones de repostiorios 
            //Logger

            builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();
            //Jessica
            builder.Services.AddScoped<IJessicaRepository, JessicaRepository>();
              builder.Services.AddScoped<IJessicaService, JessicaService>();
                //CLIENTE
               
                builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
                builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
                
                // Tipos de facturacion
                builder.Services.AddScoped<ITipoDeFacturacionRepository, TipoDeFacturacionRepository>();
                builder.Services.AddScoped<ITiposDeFacturacionService, TiposDeFacturacionService>();

                //Pacientes
                builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
                builder.Services.AddScoped<IPacienteService, PacienteService>();

            // Configurar sesiones
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();
            
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try { 
                
                    var dataContext = services.GetRequiredService<AppDbContext>();

                    dataContext.Database.Migrate();

                var jessicas = dataContext.jessicas.Find(1);
                    if(jessicas == null)
                    {
                    var passwordHasher = new PasswordHasher<object>();
                    var passwordManager = new PasswordManager(passwordHasher);
                    var email = builder.Configuration["JessicaUser:Email"];
                    var password = builder.Configuration["JessicaUser:Password"];
                    var jessi = new Jessica(email,password, passwordManager);
                    dataContext.jessicas.Add(jessi);
                    dataContext.SaveChanges();

                }
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.ToString());
                }
            }
             

                // Configure the HTTP request pipeline.  
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseMiddleware<LoggerMiddleware>();
            //app.UseSession();
            //app.UseMiddleware<SessionMiddleware>();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
