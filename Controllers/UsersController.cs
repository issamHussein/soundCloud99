using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;

        }


        [HttpGet]
        [Route("GetAllUsers")]
        public List<Users> GetAllUsers()
        {
            return userService.GetAllUsers();
        }


        [HttpPost]
        [Route("CreateUsers")]
        public bool CreateUsers([FromBody] Users user)
        {
            return userService.CreateUsers(user);    
        }



        [HttpPut]
        [Route("UpdateUsers")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        public bool UpdateUsers([FromBody] Users user)
        {
            return userService.UpdateUsers(user);
        }


        [HttpDelete]
        [Route("DeleteUsers/{id}")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        public bool DeleteUsers(int id)
        {
            return userService.DeleteUsers(id);
        }





        [HttpGet]
        [Route("GetByUserName/{userName}")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public List<Users> GetByUserName(string userName)
        {
            return userService.GetByUserName(userName);
        }






        [HttpPost]
        [Route("UploadImage")]
        public Users UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0]; //retrive file{Image} from Form which is part of the Request

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\img", fileName); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Users user = new Users();
                user.Image = fileName;
                return user;

            }
            catch (Exception e)
            {
                return null;
            }
        }






        
        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] LoginDTO loginDTO)
        {

            var token = userService.auth(loginDTO);
            if (token == null) return Unauthorized();
            else return Ok(token);

        }


        [HttpGet]
        [Route("GetByUserEmail/{email}")]
        // get the information of the login user (input:userEmail output:user object)
        public List<Users> GetByUserEmail( string email)
        {
            return userService.GetByUserEmail(email);

        }



        [HttpPost]
        [Route("GetProfitReport")]

        public List<profitReportsDTO> GetProfitReport(profitReportsDTO profitReportsDTO)
        {
            return userService.GetProfitReport(profitReportsDTO.dateFrom, profitReportsDTO.dateTo, profitReportsDTO.UserID);
        }




        [HttpPost]
        [Route("GetSumProfitReport")]
        public List<profitReportsDTO> GetSumProfitReport(profitReportsDTO profitReportsDTO)
        {
            return userService.GetSumProfitReport(profitReportsDTO.dateFrom, profitReportsDTO.dateTo, profitReportsDTO.UserID);
        }



        [HttpGet]
        [Route("GetIdByUserEmail/{email}")]
        public AmtOfSoundsDTO GetIdByUserEmail(string email)
        {
            AmtOfSoundsDTO amtOfSounds = new AmtOfSoundsDTO();
            amtOfSounds.amtOfSounds =userService.GetIdByUserEmail(email);
            return amtOfSounds;

        }



    }
}
