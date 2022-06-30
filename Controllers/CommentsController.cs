using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;
using Tahaluf.SoundCloud.Infra.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {


        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService _commentsService)
        {
            commentsService = _commentsService;
        }

        [HttpGet]
        [Route("GetAllComments/{id}")]
        // get all comment for the sound input:soundid output:array of object CommentsDTO
        public List<CommentsDTO> GetAllComments(int id)
        {
            return commentsService.GetAllComments(id);
        }

        [HttpPost]
        [Route("CreateComments")]
        public bool CreateComments([FromBody] Comments comments)
        {
            return commentsService.CreateComments(comments);
        }

        [HttpPut]
        [Route("UpdateComments")]

        public bool UpdateComments([FromBody] Comments comments)
        {
            return commentsService.UpdateComments(comments);
        }

        [HttpDelete]
        [Route("DeleteComments(/{id}")]
        public bool DeleteComments(int id)
        {
            return commentsService.DeleteComments(id);
        }



    }
}
