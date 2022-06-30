using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SoundsController : ControllerBase
    {
        private readonly ISoundsService soundsService;

        public SoundsController(ISoundsService _soundsService)
        {
            soundsService = _soundsService;
        }

        [HttpGet]
        [Route("GetAllSounds")]
        public List<Sounds> GetAllSounds()
        {
            return soundsService.GetAllSounds();
        }

        [HttpPost]
        [Route("CreateSounds")]
        public bool CreateSounds([FromBody] Sounds sounds)
        {
            var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\songs", sounds.song); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

            sounds.interval =new AudioFileReader(path).TotalTime.TotalMinutes;

            sounds.Description = "--";

            if (sounds.interval>=4)
            {
                sounds.price = (float)((sounds.interval - 4.0) * 0.5);
            }
            else
            {
                sounds.price = 0;
            }


            return soundsService.CreateSounds(sounds);
        }

        [HttpPut]
        [Route("UpdateSOUNDS")]
        public bool UpdateSound([FromBody] Sounds sounds)
        {

            var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\songs", sounds.song); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

            sounds.interval = new AudioFileReader(path).TotalTime.TotalMinutes;

            if (sounds.interval >= 4)
            {
                sounds.price = (float)((sounds.interval - 4.0) * 0.5);
            }
            else
            {
                sounds.price = 0;
            }

            return soundsService.UpdateSOUNDS(sounds);
        }

        [HttpDelete]
        [Route("DeleteSOUNDS/{id}")]
        public bool DeleteSOUNDS(int id)
        {
            return soundsService.DeleteSOUNDS(id);
        }



        [HttpGet]
        [Route("GetBySOUNDName/{SoundName}")]
        //search for all sounds
        public List<Sounds> GetBySOUNDName(string SoundName)
        {
            return soundsService.GetBySOUNDName(SoundName);
        }





        [HttpGet]
        [Route("GetTOP10Sounds")]
        public List<Top10SoundsDTO> GetTop10Sounds()
        {
            return soundsService.GetTop10Sounds();
        }








        [HttpGet]
        [Route("GetByCATEGORYID/{id}")]
        //gett all sounds for the singer
        public List<Sounds> GetByCATEGORYID(int id)
        {
            return soundsService.GetByCATEGORYID(id);
        }



        [HttpGet]
        [Route("GetBySOUNDId/{soundId}")]
        // input: sound id , output: sound object
        public List<Sounds> GetBySOUNDId(int soundId)
        {
            return soundsService.GetBySOUNDIdForAnguler(soundId);
        }



        [HttpPost]
        [Route("GetBySOUNDId")]
        public Sounds GetBySOUNDIdPost([FromBody]int soundId)
        {
            return soundsService.GetBySOUNDId(soundId);
        }



        [HttpPost]
        [Route("UploadImage")]
        public Sounds UploadImage()
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

                Sounds sound = new Sounds();
                sound.Image = fileName;
                return sound;

            }
            catch (Exception e)
            {
                return null;
            }



          
        }




        [HttpPost]
        [Route("UploadSongs")]
        public Sounds UploadSongs()
        {
            try
            {
                var file = Request.Form.Files[0]; //retrive file{Image} from Form which is part of the Request

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\songs", fileName); 

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Sounds sound = new Sounds();
                sound.song = fileName;
                return sound;
            }
            catch (Exception e)
            {
                return null;
            }




        }


        [HttpPost]
        [Route("buySound")]
        public bool buySound([FromBody] DownloadedSounds downloadedSounds)
        {
            downloadedSounds.dateOfDownload= DateTime.Now;

            return soundsService.buySound(downloadedSounds);
        }

        //[HttpPost]
        //[Route("Check")]
        //public bool Check([FromBody] DownloadedSounds downloadedSounds)
        //{

        //   var soundObj= soundsService.Check(downloadedSounds);

        //    if (soundObj.Count != 0)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;

        //}




        [HttpPost]
        [Route("Check")]
        // input: userid, sound id output: object of downloaded sound(to cheake if the user download the sound or not)
        public List<DownloadedSounds> Check([FromBody] DownloadedSounds downloadedSounds)
        {

            return soundsService.Check(downloadedSounds);

         

        }


        [HttpGet]
        [Route("soundsUploadedByTheUser/{id}")]
        public List<RetriveSoundsUploadedByUserDTO> soundsUploadedByTheUser(int id)
        {
            return soundsService.soundsUploadedByTheUser(id);
        }

        [HttpGet]
        [Route("AmountOfSoundsUploadedByTheUser/{id}")]
        public int AmountOfSoundsUploadedByTheUser(int id)
        {
            return soundsService.soundsUploadedByTheUser(id).Count();
        }


        [HttpPost]
        [Route("UserUploadSound")]

        public bool uploadSound(UploadedSounds uploadedSounds)
        {
            return soundsService.uploadSound(uploadedSounds);
        }















        [HttpPost]
        [Route("CreateSoundsByUsers")]
        //input:soundDTO whitch has userid output: create sound and object in uploaded table
        public bool CreateSoundsByUsers([FromBody] SoundsUploadedByUserDTO soundsDTO)
        {
            var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\songs", soundsDTO.song); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

            soundsDTO.interval = new AudioFileReader(path).TotalTime.TotalMinutes;
            soundsDTO.CategoryID = 181;
            soundsDTO.publishDate= DateTime.Now;
            soundsDTO.Description = "--";

            if (soundsDTO.interval >= 4)
            {
                soundsDTO.price = (float)((soundsDTO.interval - 4.0) * 0.5);
            }
            else
            {
                soundsDTO.price = 0;
            }

            //create sound object to send it to the create sound service
            Sounds sound = new Sounds();
            sound.SoundName = soundsDTO.SoundName;
            sound.interval = soundsDTO.interval;
            sound.CategoryID= soundsDTO.CategoryID;
            sound.Image= soundsDTO.Image;
            sound.price = soundsDTO.price;
            sound.song= soundsDTO.song;
            sound.Description = soundsDTO.Description;
            sound.publishDate=soundsDTO.publishDate;
            soundsService.CreateSounds(sound);

            //retrive the new song to use its id
            Sounds newSound = soundsService.GetBySOUNDName(soundsDTO.SoundName).FirstOrDefault();

            //create uploaded sound object to send it to upload sound table
            UploadedSounds uploadedSounds = new UploadedSounds();
            uploadedSounds.SoundId = newSound.SoundID;
            uploadedSounds.UploadedDate = soundsDTO.publishDate;
            uploadedSounds.UserId = soundsDTO.UserID;
            
            soundsService.uploadSound(uploadedSounds);
            return true;
        }




        [HttpGet]
        [Route("SoundDownloadedByTheUser/{id}")]
        public List<SoundDownloadedByTheUserDTO> SoundDownloadedByTheUser(int id)
        {
            return soundsService.SoundDownloadedByTheUser(id);
        }





        [HttpPut]
        [Route("UpdateSoundsByUsers")]
        //input:soundDTO whitch has userid output: create sound and object in uploaded table
        public bool UpdateSoundsByUsers([FromBody] Sounds sounds)
        {
            var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\songs", sounds.song); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

            sounds.interval = new AudioFileReader(path).TotalTime.TotalMinutes;
            sounds.CategoryID = 181;
            sounds.publishDate = DateTime.Now;
            sounds.Description = "--";

            if (sounds.interval >= 4)
            {
                sounds.price = (float)((sounds.interval - 4.0) * 0.5);
            }
            else
            {
                sounds.price = 0;
            }

            ////create sound object to send it to the update sound service
            //Sounds sound = new Sounds();
            //sound.SoundID = soundsDTO.SoundID;
            //sound.SoundName = soundsDTO.SoundName;
            //sound.interval = soundsDTO.interval;
            //sound.CategoryID = soundsDTO.CategoryID;
            //sound.Image = soundsDTO.Image;
            //sound.price = soundsDTO.price;
            //sound.song = soundsDTO.song;
            //sound.Description = soundsDTO.Description;
            //sound.publishDate = soundsDTO.publishDate;
            soundsService.UpdateSOUNDS(sounds);

            return true;
        }



    }
}
