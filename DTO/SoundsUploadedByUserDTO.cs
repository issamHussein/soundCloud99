using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.SoundCloud.Core.DTO
{
    public class SoundsUploadedByUserDTO
    {

        public int SoundID { get; set; }
        public string SoundName { get; set; }
        public double interval { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
        public DateTime publishDate { get; set; }
        public string song { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }


    }
}
