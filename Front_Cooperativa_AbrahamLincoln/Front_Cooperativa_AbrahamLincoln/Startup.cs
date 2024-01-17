using Front_Cooperativa_AbrahamLincoln.Models;

//namespace Front_Cooperativa_AbrahamLincoln
//{
public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //services.Configure<ImagenesConfig>(Configuration.GetSection("Imagenes"));
        Configuration.Bind("Imagenes", new ImagenesConfig());
    }

    public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
    {
        //CODIGO INGRESADO 11-01-2024
        //MANEJO DE EXPIRACION DE SESION
        app.UseStatusCodePages(context =>
        {
            var response = context.HttpContext.Response;

            if (response.StatusCode == 401) // Código para "No autorizado"
            {
                response.Redirect("/Login/login"); // Ajusta la ruta según tu configuración
            }

            return Task.CompletedTask;
        });
    }

}
//}
