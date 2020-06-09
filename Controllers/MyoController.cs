
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Myo.DAL;
using Myo.Models;
using Myo.Wrappers;

namespace Myo.Controllers
{

    [Authorize]
    [Route("api/v1/[controller]")]
    public class MyoController : Controller
    {

        private readonly IUserRepository userRepository;
        private readonly IMyoRepository myoRepository;
        public MyoController(IUserRepository userRepository, IMyoRepository myoRepository)
        {
            this.userRepository = userRepository;
            this.myoRepository = myoRepository;
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateNewMyo([FromBody] Myo.Models.Myo myo)
        {
            // Checking mandatory fields
            if (string.IsNullOrEmpty(myo.Title) || string.IsNullOrEmpty(myo.Goal) || myo.Owner == null)
                return Json(new SimpleResponser{ Success = false, Message = "Title, Goal and Owner are mandatory fields."});

            // Checking owner exists
            var user = userRepository.GetUserById(myo.Owner.IdUser);
            if (user == null)
                return Json(new SimpleResponser { Success = false, Message = "The user cannot be found in the database."});

            // Inserting the new Myo
            myoRepository.CreateMyo(myo);
            myoRepository.Save();

            return Json(new SimpleResponser { Success = true, Message = "Your Myo has been created correctly!"});
        }

    }
}