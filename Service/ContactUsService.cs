using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsService(IContactUsRepository _contactUsRepository)
        {
            this.contactUsRepository = _contactUsRepository;
        }


        public bool CreateContactUs(ContactUs contactUs)
        {
            return contactUsRepository.CreateContactUs(contactUs);
        }

        public bool DeleteContactUs(int id)
        {
            return contactUsRepository.DeleteContactUs(id);
        }

        public List<ContactUs> GetAllContactUs()
        {
            return contactUsRepository.GetAllContactUs();
        }
    }
}
