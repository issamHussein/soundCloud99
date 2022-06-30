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
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService testimonialService;

        public TestimonialController(ITestimonialService _testimonialService)
        {
            testimonialService = _testimonialService;

        }


        [HttpGet]
        [Route("GetAllTestimonial")]
        public List<TestimonialDTO> GetAllTestimonial()
        {
            return testimonialService.GetAllTestimonial();
        }


        [HttpPost]
        [Route("CreateTestimonial")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return testimonialService.CreateTestimonial(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimonial")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        public bool UpdateTestimonial([FromBody] AproveTestDTO testimonial)
        {
            return testimonialService.UpdateTestimonial(testimonial);
        }


        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]

        //200 ok
        //404 page not found == problem in controller
        //400 bad request == مشكله في الداتا يلي بتنبعث
        //401 unautherization
        public bool DeleteTestimonial(int id)
        {
            return testimonialService.DeleteTestimonial(id);
        }











        //[HttpPost]
        //[Route("UploadImage")]
        //public Sounds UploadImage()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0]; //retrive file{Image} from Form which is part of the Request

        //        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //        var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\img", fileName); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }

        //        Testimonial test = new Testimonial();
        //        test.Image = fileName;
        //        return sound;

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}










    }
}
