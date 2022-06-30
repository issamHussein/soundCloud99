using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class purchaseController : ControllerBase
    {


        private readonly IVisaCardService visaCardService;
        private readonly ISoundsService soundsService;

        public purchaseController(IVisaCardService _visaCardService, ISoundsService _soundsService)
        {
            visaCardService = _visaCardService;
            soundsService = _soundsService;
        }






        [HttpPost]
        [Route("purchases")]
        // input:purchaseDTO output: true if the payment done succssesfully and false if not (check the visa information and if the balance enough)
        public bool purchase([FromBody] purchaseDTO purchase)
        {
            VisaCard visaObj = new VisaCard ();

            //input:card information outout:visa object (check the visa information if found it in the db return visa object,  if not return null)
            visaObj = visaCardService.CheckVisa(purchase.VisaID,purchase.CCV , purchase.ExpireDate, purchase.Expiredyear );

            Sounds soundObj = new Sounds();
            // return the sound information
           soundObj = soundsService.GetBySOUNDId(purchase.SoundID);

            DownloadedSounds downloaded=new DownloadedSounds();

            if (visaObj!=null)
            {
                 if (visaObj.Balance>=soundObj.price)
                 {
                visaObj.Balance = visaObj.Balance-soundObj.price;

                //change the balance into the new balance after the purches done
                visaCardService.UpdateBalance(visaObj.VisaID , visaObj.Balance);


                downloaded.UserID = purchase.UserID;
                downloaded.SoundID= purchase.SoundID;
                downloaded.dateOfDownload= DateTime.Now;
                //to save the information in the downloaded table
                soundsService.buySound(downloaded);
                return true;
                 }
                 else
                 {
                return false;
                 }
           
            }
            else
            {
                return false;
            }
        }

        }





    }

