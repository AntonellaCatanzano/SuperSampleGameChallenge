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
    [RoutePrefix("api/Niveles")]
    public class NivelesController : ApiController
    {
        private IMapper _mapper;

        private readonly NivelService _nivelService = new NivelService(new NivelRepository(SuperSampleGameContext.Create()));

        public NivelesController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            var niveles = await _nivelService.GetAll();

            var nivelesDTO = niveles.Select(d => _mapper.Map<NivelDTO>(d));

            return Ok(nivelesDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var nivel = await _nivelService.GetById(id);

            if (nivel == null)
            {
                return NotFound();
            }

            var nivelDTO = _mapper.Map<NivelDTO>(nivel);

            return Ok(nivelDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(NivelDTO nivelDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nivel = _mapper.Map<Nivel>(nivelDTO);
                
                if (nivelDTO.Grado == 10)
                {
                    nivel = await _nivelService.Insert(nivel);
                }                   

                return Ok(nivel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(NivelDTO nivelDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (nivelDTO.IdNivel != id)
            {
                return BadRequest();
            }

            var nivel = await _nivelService.GetById(id);

            if (nivel == null)
            {
                return NotFound();
            }

            try
            {
                nivel = _mapper.Map<Nivel>(nivelDTO);

                nivel = await _nivelService.Update(nivel);

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
            var flag = await _nivelService.GetById(id);

            if (flag == null)
            {
                return BadRequest();
            }

            try
            {
                if (!await _nivelService.DeleteOnCheckEntity(id))
                {
                    await _nivelService.Delete(id);
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
