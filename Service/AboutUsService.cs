using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class AboutUsService : IAboutUsService
    {

        private readonly IAboutUsRepository aboutUsRepository;

        public AboutUsService(IAboutUsRepository _aboutUsRepository)
        {
            aboutUsRepository = _aboutUsRepository;
        }



        public bool CreateAboutUs(AboutUs aboutUs)
        {
            return aboutUsRepository.CreateAboutUs(aboutUs);
        }

        public bool DeleteAboutUs(int id)
        {
            return aboutUsRepository.DeleteAboutUs(id);
        }

        public List<AboutUs> GetAllAboutUs()
        {
            return aboutUsRepository.GetAllAboutUs();
        }

        public bool UpdateAboutUs(AboutUs aboutUs)
        {
            return aboutUsRepository.UpdateAboutUs(aboutUs);
        }
    }
}
