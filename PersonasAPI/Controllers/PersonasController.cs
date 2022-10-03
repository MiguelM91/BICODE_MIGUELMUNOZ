using BussinesLogicLibrary;
using BussinesLogicLibrary.Exceptions;
using BussinesLogicLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PersonasAPI.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IPersonaService _personaService;
        
        public PersonasController( IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public ApiResponse Get()
        {
            var personas = _personaService.GetPersonas();
            var result = new ApiResponse()
            {
                Result = personas,
                Message = "Ok",
                State = true
            };

            return result;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public ActionResult<ApiResponse> Get(int id)
        {
            try
            {
                var persona = _personaService.GetPersona(id);
                var result = new ApiResponse()
                {
                    Result = persona,
                    Message = "Ok",
                    State = true
                };

                return new OkObjectResult(result);
            }
            catch (ResourceNotFoundException)
            {

                var result = new ApiResponse()
                {
                    Message = "Not Found",
                    State = false
                };

                return new NotFoundObjectResult(result);
            }
            catch (Exception e) {
                
                var result = new ApiResponse()
                {
                    
                    Message = e.Message,
                    State = true
                };

                return new ObjectResult(result) {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        // POST api/<PersonasController>
        [HttpPost]
        public ActionResult<ApiResponse> Post([FromBody] PersonaInputViewModel personaInput)
        {
            try
            {
                var persona = _personaService.CreatePersona(personaInput);
                var result = new ApiResponse()
                {
                    Result = persona,
                    Message = "Ok",
                    State = true
                };

                return new OkObjectResult(result);
            }
            
            catch (Exception e)
            {

                var result = new ApiResponse()
                {

                    Message = e.Message,
                    State = true
                };

                return new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public ActionResult<ApiResponse> Put(int id, [FromBody] PersonaInputViewModel personaInput)
        {
            try
            {
                var persona = _personaService.UpdatePersona(personaInput, id);
                var result = new ApiResponse()
                {
                    Result = persona,
                    Message = "Ok",
                    State = true
                };

                return new OkObjectResult(result);
            }
            catch (ResourceNotFoundException)
            {

                var result = new ApiResponse()
                {
                    Message = "Not Found",
                    State = false
                };

                return new NotFoundObjectResult(result);
            }
            catch (Exception e)
            {

                var result = new ApiResponse()
                {

                    Message = e.Message,
                    State = true
                };

                return new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse> Delete(int id)
        {
            try
            {
                _personaService.DeletePersona(id);
                var result = new ApiResponse()
                {                   
                    Message = "Ok",
                    State = true
                };

                return new OkObjectResult(result);
            }
            catch (ResourceNotFoundException)
            {

                var result = new ApiResponse()
                {
                    Message = "Not Found",
                    State = false
                };

                return new NotFoundObjectResult(result);
            }
            catch (Exception e)
            {

                var result = new ApiResponse()
                {

                    Message = e.Message,
                    State = true
                };

                return new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
