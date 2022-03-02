using AutoMapper;
using SuperSampleGame.Negocio.Models;

namespace SuperSampleGame.Negocio.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guerrero, GuerreroDTO>(); // GET
                cfg.CreateMap<GuerreroDTO, Guerrero>(); // POST - PUT

                cfg.CreateMap<Destreza, DestrezaDTO>(); // GET
                cfg.CreateMap<GuerreroDTO, Destreza>(); // POST - PUT

                cfg.CreateMap<GuerreroDestreza, GuerreroDestrezaDTO>(); // GET
                cfg.CreateMap<GuerreroDestrezaDTO, GuerreroDestreza>(); // POST - PUT

                cfg.CreateMap<Nivel, NivelDTO>(); // GET
                cfg.CreateMap<NivelDTO, Nivel>(); // POST - PUT

                cfg.CreateMap<Equipamiento, EquipamientoDTO>(); // GET
                cfg.CreateMap<EquipamientoDTO, Equipamiento>(); // POST - PUT

                cfg.CreateMap<Jugador, JugadorDTO>(); // GET
                cfg.CreateMap<JugadorDTO, Jugador>(); // POST - PUT

                cfg.CreateMap<JugadorEquipamiento, JugadorEquipamientoDTO>(); // GET
                cfg.CreateMap<JugadorEquipamientoDTO, JugadorEquipamiento>(); // POST - PUT

                cfg.CreateMap<Categoria, CategoriaDTO>(); // GET
                cfg.CreateMap<CategoriaDTO, Categoria>(); // POST - PUT
            });
        }
    }
}
