using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {

        private readonly ILikesService likesService;

        public LikesController(ILikesService _likesService)
        {
            likesService = _likesService;
        }




        [HttpGet]
        [Route("GetAmountOfLikes")]
        //get the amount of likes for each sound
        public List<AmtOfLikesDTO> GetAmountOfLikes()
        {
            return likesService.GetAmountOfLikes();
        }



        [HttpPost]
        [Route("CreateLikes")]
        //input:like object(userid and soundid) output: true if the user didn't like the sound before, false if he already like the sound
        public bool CreateLikes(Likes like)
        {
               Likes likeObj = new Likes();
            //return like object if the user liked the sound before else return null
            likeObj=likesService.CheckLike(like);

            if (likeObj!=null)
            {
                return likesService.DeleteLike(likeObj.LikeID); ;

            }
            return likesService.CreateLikes(like);

        }



        [HttpDelete]
        [Route("DeleteLike")]
        public bool DeleteLike(int id)
        {
            return likesService.DeleteLike(id);
        }


        [HttpPost]
        [Route("CheckLike")]
        public Likes CheckLike(Likes like)
        {
            return likesService.CheckLike(like);
        }
    }
}
