using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class HomePageService : IHomePageService
    {



        private readonly IHomePageRepository homePageRepository;

        public HomePageService(IHomePageRepository _homePageRepository)
        {
            homePageRepository = _homePageRepository;
        }


        public bool CreateHomePage(Home home)
        {
            return homePageRepository.CreateHomePage(home);
        }

        public bool DeleteHomePage(int id)
        {
            return homePageRepository.DeleteHomePage(id);
        }

        public List<Home> GetAllHomePage()
        {
            return homePageRepository.GetAllHomePage();
        }

        public bool UpdateHomePage(Home home)
        {
            return homePageRepository.UpdateHomePage(home);
        }
    }
}
