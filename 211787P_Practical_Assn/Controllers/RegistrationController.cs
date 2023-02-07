using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.Services;
using _211787P_Practical_Assn.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _211787P_Practical_Assn.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class RegistrationController : ControllerBase
    {

        private readonly IRegistration service;

        public RegistrationController(IRegistration _service)

        {

            this.service = _service;

        }
        [HttpPost]

        public async Task<IActionResult> Registration([FromForm] Registration request)

        {

            if (request == null)

            {

                return BadRequest(new RegistrationResponse() { Success = false, Error = "Invalid registration request" });

            }



            if (!ModelState.IsValid)

            {

                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList();

                if (errors.Any())

                {

                    return BadRequest(new RegistrationResponse

                    {

                        Error = $"{string.Join(",", errors)}"

                    });

                }

            }



            var response = await service.Registration(request);



            if (!response.Success)

            {

                return UnprocessableEntity(response);

            }



            return Ok(new RegistrationResponse() { Success = true });



        }

    }

}