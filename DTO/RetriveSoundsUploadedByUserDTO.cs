using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.SoundCloud.Core.DTO
{
    public class RetriveSoundsUploadedByUserDTO
    {
        public int soundid { get; set; }
        public string SoundName { get; set; }
        public string Image { get; set; }
        public float price { get; set; }
        public DateTime publishDate { get; set; }
        public string song { get; set; }

    }
}
