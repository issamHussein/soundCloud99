using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Service;
using Tahaluf.SoundCloud.Infra.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService _contactUs)
        {
            contactUsService = _contactUs;
        }

        [HttpGet]
        [Route("GetAllContactUs")]
        public List<ContactUs> GetAllContactUs()
        {
            return contactUsService.GetAllContactUs();
        }

        [HttpPost]
        [Route("CreateContactUs")]
        public bool CreateContactUs([FromBody] ContactUs contactUs)
        {
            return contactUsService.CreateContactUs(contactUs);
        }
        [HttpDelete]
        [Route("DeleteContactUs/{id}")]
        public bool DeleteContactUs(int id)
        {
            return contactUsService.DeleteContactUs(id);
        }

    }
}
