using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;
using Tahaluf.SoundCloud.Infra.Repository;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository commentRepository;

        public CommentsService(ICommentsRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }

        public bool CreateComments(Comments comments)
        {
          return commentRepository.CreateComments(comments);
        }

        public bool DeleteComments(int id)
        {
           return commentRepository.DeleteComments(id);
        }

        public List<CommentsDTO> GetAllComments(int id)
        {
           return commentRepository.GetAllComments(id);
        }

        public bool UpdateComments(Comments comments)
        {
           return commentRepository.UpdateComments(comments);
        }
    }
}
