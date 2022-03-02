using SuperSampleGame.Negocio.DTOs;
using System.Web.Http;

namespace SuperSampleGame.WebApi.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        ///  Método encarggado de realizar la Autenticación
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Demo Testing
            bool credencialValida = (loginDTO.Password == "adminSSG2022");

            if(credencialValida)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);

                return Ok(token);

            } else
            {
                return Unauthorized(); // Status 401
            }

            
        }
    }
}
