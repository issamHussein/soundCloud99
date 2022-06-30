using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.SoundCloud.Core.Data
{
    public class Sounds
    {
        [Key]
        public int SoundID { get; set; }
        public string SoundName { get; set; }
        public double interval { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
        public DateTime publishDate { get; set; }
        public string song { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public virtual Category category { get; set; }
        public ICollection<Comments> comments { get; set; }
        public ICollection<Cart> cart { get; set; }
        public ICollection<Favourite> favourite { get; set; }
        public ICollection<Likes> likes { get; set; }

        public ICollection<OrderSounds> orderSounds { get; set; }

        public ICollection<DownloadedSounds> downloadedSounds { get; set; }
        public ICollection<UploadedSounds> uploadedSounds { get; set; }


    }
}
