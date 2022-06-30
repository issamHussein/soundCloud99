using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisaCardController : ControllerBase
    {


        private readonly IVisaCardService visaCardService;

        public VisaCardController(IVisaCardService _visaCardService)
        {
            visaCardService = _visaCardService;
        }



        [HttpPost]
        [Route("CheckVisa")]

        public VisaCard CheckVisa([FromBody] int VisaID, int CCV, string ExpireDate, string Expiredyear)
        {
            return visaCardService.CheckVisa( VisaID,  CCV, ExpireDate, Expiredyear);
        }



        [HttpPost]
        [Route("UpdateBalance")]
        public bool UpdateBalance([FromBody] int VisaID, double Balance)
        {
            return visaCardService.UpdateBalance(VisaID, Balance);
        }






    }
}
