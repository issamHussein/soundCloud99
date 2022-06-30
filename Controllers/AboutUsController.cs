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
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService aboutUsService;

        public AboutUsController(IAboutUsService _aboutUsService)
        {
            aboutUsService = _aboutUsService;
        }

        [HttpGet]
        [Route("GetAllAboutUs")]
        public List<AboutUs> GetAllAboutUs()
        {
            return aboutUsService.GetAllAboutUs();
        }

        [HttpPost]
        [Route("CreateAboutUs")]
        public bool CreateAboutUs([FromBody] AboutUs aboutUs)
        {
            return aboutUsService.CreateAboutUs(aboutUs);
        }

        [HttpPut]
        [Route("UpdateAboutUs")]

        public bool UpdateAboutUs([FromBody] AboutUs aboutUs)
        {
            return aboutUsService.UpdateAboutUs(aboutUs);
        }

        [HttpDelete]
        [Route("DeleteAboutUs/{id}")]
        public bool DeleteAboutUs(int id)
        {
            return aboutUsService.DeleteAboutUs(id);
        }



        [HttpPost]
        [Route("UploadImage")]
        public AboutUs UploadImage()
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

                AboutUs aboutUs = new AboutUs();
                aboutUs.Image = fileName;
                return aboutUs;

            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
