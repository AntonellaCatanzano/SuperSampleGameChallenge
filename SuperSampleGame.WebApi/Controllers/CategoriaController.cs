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
    [RoutePrefix("api/Categorias")]
    public class CategoriaController : ApiController
    {
        private IMapper _mapper;
        
        private readonly CategoriaService _categoriaService = new CategoriaService(new CategoriaRepository(SuperSampleGameContext.Create()));

        public CategoriaController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAll();

            var categoriasDTO = categorias.Select(d => _mapper.Map<CategoriaDTO>(d));

            return Ok(categoriasDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(DestrezaDTO categoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var categoria = _mapper.Map<Categoria>(categoriaDTO);

                categoria = await _categoriaService.Insert(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CategoriaDTO categoriaDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoriaDTO.IdCategoria != id)
            {
                return BadRequest();
            }

            var categoria = await _categoriaService.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                categoria = _mapper.Map<Categoria>(categoriaDTO);

                categoria = await _categoriaService.Update(categoria);

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
            var flag = await _categoriaService.GetById(id);

            if (flag == null)
            {
                return BadRequest();
            }

            try
            {
                if (!await _categoriaService.DeleteOnCheckEntity(id))
                {
                    await _categoriaService.Delete(id);
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
