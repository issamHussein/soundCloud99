using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class LikesService : ILikesService
    {

        private readonly ILikesRepository likesRepository;

        public LikesService(ILikesRepository _likesRepository)
        {
            likesRepository = _likesRepository;
        }


        public bool CreateLikes(Likes like)
        {
            return likesRepository.CreateLikes(like);
        }

        public bool DeleteLike(int id)
        {
            return likesRepository.DeleteLike(id);
        }

        public List<AmtOfLikesDTO> GetAmountOfLikes()
        {
            return likesRepository.GetAmountOfLikes( );
        }
        public Likes CheckLike(Likes like)
        {
            return likesRepository.CheckLike(like);
        }

    }
}
