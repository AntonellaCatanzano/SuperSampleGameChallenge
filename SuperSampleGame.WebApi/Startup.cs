using Owin;
using SuperSampleGame.Negocio.Data;


namespace SuperSampleGame.WebApi
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configura el DbContext para poder utilizarlo como una única Instancia por cada Request
            app.CreatePerOwinContext(SuperSampleGameContext.Create);
        }
    }
}
