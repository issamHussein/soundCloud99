using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.SoundCloud.Core.DTO
{
    public class SoundDownloadedByTheUserDTO
    {
        public int SoundID { get; set; }
        public string SoundName { get; set; }
        public string Image { get; set; }
        public DateTime dateofdownload { get; set; }
        public string song { get; set; }
        public int UserID { get; set; }




    }
}
