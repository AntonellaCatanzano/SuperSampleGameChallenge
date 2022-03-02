using AutoMapper;
using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.DTOs;
using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories.Implements;
using SuperSampleGame.Negocio.Services;
using SuperSampleGame.Negocio.Services.Implements;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperSampleGame.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Guerreros")]
    public class GuerrerosController : ApiController
    {
        private IMapper _mapper;

        private readonly GuerreroService _guerreroService = new GuerreroService(new GuerreroRepository(SuperSampleGameContext.Create()));

        public GuerrerosController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            var guerreros = await _guerreroService.GetAll();

            var guerrerosDTO = guerreros.Select(g => _mapper.Map<GuerreroDTO>(g));

            return Ok(guerrerosDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var guerrero = await _guerreroService.GetById(id);

            if (guerrero == null)
            {
                return NotFound();
            }

            var guerreroDTO = _mapper.Map<GuerreroDTO>(guerrero);

            return Ok(guerreroDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(GuerreroDTO guerreroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var guerrero = _mapper.Map<Guerrero>(guerreroDTO);

                guerrero = await _guerreroService.Insert(guerrero);

                return Ok(guerrero);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(GuerreroDTO guerreroDTO, int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(guerreroDTO.IdGuerrero != id)
            {
                return BadRequest();
            }

            var flag = await _guerreroService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                var guerrero = _mapper.Map<Guerrero>(guerreroDTO);

                guerrero = await _guerreroService.Update(guerrero);

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
            var flag = await _guerreroService.GetById(id);

            if(flag == null)
            {
                return BadRequest();
            }

            try
            {
                if(!await _guerreroService.DeleteOnCheckEntity(id))
                {
                    await _guerreroService.Delete(id);
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
