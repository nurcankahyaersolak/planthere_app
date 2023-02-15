using AuthServer.API.CustomResponses;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(CustomResponse<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}