using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {

        private readonly IHomePageService homePageService;

        public HomePageController(IHomePageService _homePageService)
        {
            homePageService = _homePageService;
        }

        [HttpGet]
        [Route("GetAllHomePage")]
        public List<Home> GetAllAdmin()
        {
            return homePageService.GetAllHomePage();
        }

        [HttpPost]
        [Route("CreateHomePage")]
        public bool CreateHomePage([FromBody] Home home)
        {
            return homePageService.CreateHomePage(home);
        }

        [HttpPut]
        [Route("UpdateHomePage")]

        public bool UpdateHomePage([FromBody] Home home)
            
        {
            return homePageService.UpdateHomePage(home);
        }

        [HttpDelete]
        [Route("DeleteHomePage/{id}")]
        public bool DeleteHomePage(int id)
        {
            return homePageService.DeleteHomePage(id);
        }





        [HttpPost]
        [Route("UploadImage")]
        public Home UploadImage()
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

                Home home = new Home();
                home.Image1 = fileName;
                return home;

            }
            catch (Exception e)
            {
                return null;
            }
        }




    }
}
