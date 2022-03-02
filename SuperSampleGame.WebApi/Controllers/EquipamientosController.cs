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
    [RoutePrefix("api/Equipamientos")]
    public class EquipamientosController : ApiController
    {
        private IMapper _mapper;

        private readonly EquipamientoService _equipamientoService = new EquipamientoService(new EquipamientoRepository(SuperSampleGameContext.Create()));

        public EquipamientosController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            var equipamientos = await _equipamientoService.GetAll();

            var equipamientosDTO = equipamientos.Select(d => _mapper.Map<EquipamientoDTO>(d));

            return Ok(equipamientosDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var equipamiento = await _equipamientoService.GetById(id);

            if (equipamiento == null)
            {
                return NotFound();
            }

            var equipamientoDTO = _mapper.Map<EquipamientoDTO>(equipamiento);

            return Ok(equipamientoDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(EquipamientoDTO equipamientoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var equipamiento = _mapper.Map<Equipamiento>(equipamientoDTO);

                equipamiento = await _equipamientoService.Insert(equipamiento);

                return Ok(equipamiento);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(EquipamientoDTO equipamientoDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (equipamientoDTO.IdEquipamiento != id)
            {
                return BadRequest();
            }

            var equipamiento = await _equipamientoService.GetById(id);

            if (equipamiento == null)
            {
                return NotFound();
            }

            try
            {
                equipamiento = _mapper.Map<Equipamiento>(equipamientoDTO);

                equipamiento = await _equipamientoService.Update(equipamiento);

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
            var flag = await _equipamientoService.GetById(id);

            if (flag == null)
            {
                return BadRequest();
            }

            try
            {
                if (!await _equipamientoService.DeleteOnCheckEntity(id))
                {
                    await _equipamientoService.Delete(id);
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
