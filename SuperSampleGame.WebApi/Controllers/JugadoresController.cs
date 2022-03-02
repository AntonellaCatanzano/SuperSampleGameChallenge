using AutoMapper;
using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.DTOs;
using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories.Implements;
using SuperSampleGame.Negocio.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperSampleGame.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Jugadores")]
    public class JugadoresController : ApiController
    {
        private IMapper _mapper;

        private readonly JugadorService _jugadorService = new JugadorService(new JugadorRepository(SuperSampleGameContext.Create()));

        public JugadoresController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            var jugadores = await _jugadorService.GetAll();

            var jugadoresDTO = jugadores.Select(g => _mapper.Map<JugadorDTO>(g));

            return Ok(jugadoresDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var jugador = await _jugadorService.GetById(id);

            if (jugador == null)
            {
                return NotFound();
            }

            var jugadorDTO = _mapper.Map<JugadorDTO>(jugador);

            return Ok(jugadorDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(JugadorDTO jugadorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jugador = _mapper.Map<Jugador>(jugadorDTO);

                jugador = await _jugadorService.Insert(jugador);

                return Ok(jugador);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> EquiparGuerrero(JugadorDTO jugadorDTO, JugadorEquipamientoDTO jugadorEquipamiento, EquipamientoDTO equipamientoDTO, int oros, int diamantes, int idEquipamiento, int costo, string medida)
        {
            jugadorDTO.Oro = oros;
            jugadorDTO.Diamantes = diamantes;
            equipamientoDTO.IdEquipamiento = idEquipamiento;
            equipamientoDTO.Costo = costo;
            equipamientoDTO.Medida = medida;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jugador = _mapper.Map<Jugador>(jugadorDTO);

                var equipamiento = _mapper.Map<Jugador>(equipamientoDTO);

                var jugadorequipamiento = _mapper.Map<Jugador>(equipamientoDTO);

                if (jugadorDTO.Oro >= equipamientoDTO.Costo && equipamientoDTO.Medida == "Oro")
                {
                    oros -= costo;

                    return Ok();
                }

                if (jugadorDTO.Oro <= equipamientoDTO.Costo && equipamientoDTO.Medida == "Oro")
                {              

                    return BadRequest();
                }


                if (jugadorDTO.Diamantes >= equipamientoDTO.Costo && equipamientoDTO.Medida == "Diamantes")
                {

                    diamantes -= costo;

                    return Ok();
                }

                if (jugadorDTO.Diamantes <= equipamientoDTO.Costo && equipamientoDTO.Medida == "Diamantes")
                {                  

                    return BadRequest();
                }

                return Ok(jugador);

                          
            }


            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(JugadorDTO jugadorDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (jugadorDTO.IdJugador != id)
            {
                return BadRequest();
            }

            var jugador = await _jugadorService.GetById(id);

            if (jugador == null)
            {
                return NotFound();
            }

            try
            {
                jugador = _mapper.Map<Jugador>(jugadorDTO);

                jugador = await _jugadorService.Update(jugador);

                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await _jugadorService.GetById(id);

            if (flag == null)
            {
                return BadRequest();
            }

            try
            {
                if (!await _jugadorService.DeleteOnCheckEntity(id))
                {
                    await _jugadorService.Delete(id);
                }
                else
                {
                    throw new Exception("Contiene campos con claves Foráneas");
                }

                return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }


        }
        
    }
}
