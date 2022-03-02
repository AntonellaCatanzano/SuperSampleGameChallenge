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
    [RoutePrefix("api/Destrezas")]
    public class DestrezasController : ApiController
    {
        
            private IMapper _mapper;

            private readonly DestrezaService _destrezaService = new DestrezaService(new DestrezaRepository(SuperSampleGameContext.Create()));

            public DestrezasController()
            {
                _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            }

            [HttpGet]

            public async Task<IHttpActionResult> GetAll()
            {
                var destrezas = await _destrezaService.GetAll();

                var destrezasDTO = destrezas.Select(d => _mapper.Map<DestrezaDTO>(d));

                return Ok(destrezasDTO);
            }

            [HttpGet]

            public async Task<IHttpActionResult> GetById(int id)
            {
                var destreza = await _destrezaService.GetById(id);

                if (destreza == null)
                {
                    return NotFound();
                }

                var destrezaDTO = _mapper.Map<DestrezaDTO>(destreza);

                return Ok(destrezaDTO);
            }

            [HttpPost]
            public async Task<IHttpActionResult> Create(DestrezaDTO destrezaDTO)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    var destreza = _mapper.Map<Destreza>(destrezaDTO);

                    destreza = await _destrezaService.Insert(destreza);

                    return Ok(destreza);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }

        [HttpPut]
        public async Task<IHttpActionResult> Put(DestrezaDTO destrezaDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (destrezaDTO.IdDestreza != id)
            {
                return BadRequest();
            }

            var destreza = await _destrezaService.GetById(id);

            if (destreza == null)
            {
                return NotFound();
            }

            try
            {
                destreza = _mapper.Map<Destreza>(destrezaDTO);

                destreza = await _destrezaService.Update(destreza);

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
            var flag = await _destrezaService.GetById(id);

            if (flag == null)
            {
                return BadRequest();
            }

            try
            {
                if (!await _destrezaService.DeleteOnCheckEntity(id))
                {
                    await _destrezaService.Delete(id);
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
