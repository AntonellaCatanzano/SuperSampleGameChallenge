using SuperSampleGame.Negocio.Models;
using System.Data.Entity;

namespace SuperSampleGame.Negocio.Data
{
    public class SuperSampleGameContext : DbContext
    {
        // private static SuperSampleGameContext _superSampleGameContext = null;

        public SuperSampleGameContext() : base("SuperSampleGameContext")
        {
            
        }

        public DbSet<Guerrero> Guerreros { get; set; }

        public DbSet<Destreza> Destrezas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Nivel> Niveles { get; set; }

        public DbSet<Equipamiento> Equipamiento { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<GuerreroDestreza> GuerrerosDestrezas { get; set; }

        public DbSet<JugadorEquipamiento> JugadoresEquipamiento { get; set; }

        // Aplicación de Patrón Singleton
        public static SuperSampleGameContext Create()
        {
            return new SuperSampleGameContext();

            /*if (_superSampleGameContext == null)
            {
                _superSampleGameContext = new SuperSampleGameContext();
            }*/


            // return _superSampleGameContext;
        }

            
    }
}
