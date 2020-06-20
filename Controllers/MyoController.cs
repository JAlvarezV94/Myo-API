using System;
using System.Collections.Generic;
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
        [Authorize]
        [Route("[action]")]
        public IActionResult CreateNewMyo([FromBody] Myo.Models.Myo myo)
        {
            // Checking mandatory fields
            if(myo == null)
                return Json(new SimpleResponser { Success = false, Message = "There was a problem."});

            if (string.IsNullOrEmpty(myo.Title) || string.IsNullOrEmpty(myo.Goal) || myo.EndDate == null || myo.OwnerIdUser == 0)
                return Json(new SimpleResponser{ Success = false, Message = "Title, Goal, End Date and Owner are mandatory fields."});

            // Checking the end date is a valid one.
            if (myo.EndDate <= DateTime.Now)
                return Json(new SimpleResponser { Success = false, Message = "The date is not valid."});

            // Checking owner exists
            var user = userRepository.GetUserById(myo.OwnerIdUser);
            if (user == null)
                return Json(new SimpleResponser { Success = false, Message = "The user cannot be found in the database."});

            // If there is any checkpoint, checking fields are ok.
            if(myo.CheckpointList != null && myo.CheckpointList.Count > 0)
            {
                foreach(Checkpoint current in myo.CheckpointList)
                {
                    if(current.Date == null || current.Date <= myo.EndDate)
                        return Json(new SimpleResponser { Success = false, Message = "The date of a checkpoitn can not be lower than the end date of the goal." });

                    if(string.IsNullOrEmpty(current.TestDescription))
                        return Json(new SimpleResponser { Success = false, Message = "The description is mandatory for a checkpoint."});
                }
            }

            // Inserting the new Myo
            myoRepository.CreateMyo(myo);
            myoRepository.Save();

            return Json(new SimpleResponser { Success = true, Message = "Your Myo has been created correctly!"});
        }


        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public IActionResult ListMyoByUser([FromHeader]int idUser)
        {

            // Check user exist
            if (idUser > 1)
                return Json(new SimpleResponser { Success = false, Message = "User is necessary."});

            var user = userRepository.GetUserById(idUser);
            if(user == null)
                return Json(new SimpleResponser { Success = false, Message = "User does not exists."});

            // Get the list of myos
            var myoList = myoRepository.ListMyosByUser(idUser);

            return Json(new ComplexResponser<List<Myo.Models.Myo>> { Success = true, Message = "Myos obtained correctly.", Result = myoList});
        }


        [HttpPut]
        [Authorize]
        [Route("[action]")]
        public IActionResult UpdateMyo([FromBody] Models.Myo myo)
        {
            // Check Mandatory Fields
            if (myo.IdMyo <= 0 || myo.OwnerIdUser <= 0 || string.IsNullOrEmpty(myo.Title) 
            || string.IsNullOrEmpty(myo.Goal))
                return Json(new SimpleResponser { Success = false, Message = "Id, Title and Goal are Mandatory Fields." });

            if (DateTime.Compare(myo.EndDate, DateTime.Today) <= 0)
                return Json(new SimpleResponser { Success = false, Message = "The goal date cannot be today or before. Things need time my friend." });

            // Check Myo Exists
            var myoToUpdate = myoRepository.GetMyoById(myo.IdMyo);
            if(myoToUpdate == null)
                return Json(new SimpleResponser { Success = false, Message = "Cannot find this Myo in the database." });

            // Update Myo
            myoToUpdate = myo;
            myoRepository.UpdateMyo(myoToUpdate);
            myoRepository.Save();

            return Json(new SimpleResponser { Success = true, Message = "Myo updated correctly." });
        }

        [HttpDelete]
        [Authorize]
        [Route("[action]/{id}")]
        public IActionResult DeleteMyo(int id)
        {
            // Check the user has this Myo
            if (id <= 0)
                return Json(new SimpleResponser { Success = false, Message = "The Myo is not in the database." });

            var myo = myoRepository.GetMyoById(id);
            if(myo == null)
                return Json(new SimpleResponser { Success = false, Message = "The Myo is not in the database." });

            // Delete the Myo
            myoRepository.DeleteMyo(myo);
            myoRepository.Save();

            return Json(new SimpleResponser { Success = true, Message = "The Myo was delete." });
        }
    }
}