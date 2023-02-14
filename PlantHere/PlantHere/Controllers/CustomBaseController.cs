using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.WebAPI.CustomResults;

namespace PlantHere.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class CustomBaseController : Controller
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResult<T> response)
        {
            if (response.StatusCode == 204)// No Content
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            else
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
        }
    }
}
