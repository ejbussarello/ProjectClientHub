using Microsoft.AspNetCore.Mvc;
using ProjectClientHub.API.UseCases.Clients.Register;
using ProjectClientHub.Communication.Requests;
using ProjectClientHub.Communication.Responses;
using ProjectClientHub.Exceptions.ExceptionsBase;

namespace ProjectClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ProjectClientHubException ex) 
            {
                var errors = ex.GetErros();
                return BadRequest(new ResponseErrorMessageJson(errors));  
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson("ERRO DESCONHECIDO"));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
