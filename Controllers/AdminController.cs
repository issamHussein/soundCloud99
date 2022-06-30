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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpGet]
        [Route("GetAllAdmin")]
        public List<Admin> GetAllAdmin()
        {
            return adminService.GetAllAdmin();
        }

        [HttpPost]
        [Route("CreateAdmin")]
        public bool CreateAdmin([FromBody] Admin admin)
        {
            return adminService.CreateAdmin(admin);
        }

        [HttpPut]
        [Route("UpdateAdmin")]

        public bool UpdateAdmin([FromBody] Admin admin)
        {
            return adminService.UpdateAdmin(admin);
        }

        [HttpDelete]
        [Route("DeleteAdmin/{id}")]
        public bool DeleteAdmin(int id)
        {
            return adminService.DeleteAdmin(id);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] LoginDTO loginDTO)
        {

            var token = adminService.auth(loginDTO);
            if (token == null) return Unauthorized();
            else return Ok(token);

        }


        [HttpGet]
        [Route("GetByAdminEmail/{email}")]
        public List<Admin> GetByAdminEmail( string email)
        {
            return adminService.GetByAdminEmail(email);

        }


        [HttpPost]
        [Route("UploadImage")]
        public Admin UploadImage()
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

                Admin admin = new Admin();
                admin.image = fileName;
                return admin;

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
