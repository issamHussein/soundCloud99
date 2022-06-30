using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.SoundCloud.Core.Data
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       public string PhoneNumber { get; set; }

        public string Image { get; set; }





        [ForeignKey("RoleID")]
        public int RoleID { get; set; }

        public virtual Role role { get; set; }

        public ICollection<Comments> comments { get; set; }

        public ICollection<Cart> cart { get; set; }
        public ICollection<Favourite> favourite { get; set; }

        public ICollection<Likes> likes { get; set; }

        public ICollection<Testimonial> testimonials { get; set; }

        public ICollection<VisaCard> visaCards { get; set; }
        public ICollection<DownloadedSounds> downloadedSounds { get; set; }
        public ICollection<UploadedSounds> uploadedSounds { get; set; }

    }
}
