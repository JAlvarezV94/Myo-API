
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Myo.Models;

namespace Myo.Controllers
{

    [Authorize]
    [Route("api/v1/[controller]")]
    public class MyoController : Controller
    {


        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateNewMyo([FromBody] Myo.Models.Myo myo)
        {
            // Checking mandatory fields

            // Inserting the new Myo

            return null;
        }

    }
}