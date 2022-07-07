using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class TestimonialService: ITestimonialService
    {

        private readonly ITestimonialRepository testimonialRepository;

        public TestimonialService(ITestimonialRepository _testimonialRepository)
        {
            testimonialRepository = _testimonialRepository;
        }

        public List<TestimonialDTO> GetAllTestimonial()
        {
            return testimonialRepository.GetAllTestimonial();

        }

        public bool CreateTestimonial(Testimonial testimonial)
        {

            return testimonialRepository.CreateTestimonial(testimonial);
        }

        public bool UpdateTestimonial(AproveTestDTO testimonial)
        {
            return testimonialRepository.UpdateTestimonial(testimonial);
        }

        public bool DeleteTestimonial(int id)
        {
            return testimonialRepository.DeleteTestimonial(id);
        }




    }
}
