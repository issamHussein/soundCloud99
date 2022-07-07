using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.SoundCloud.Core.DTO
{
    public class profitReportsDTO
    {

        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public string SoundName { get; set; }
        public float price { get; set; }
        public DateTime dateOfDownload { get; set; }
        public float sumPrice { get; set; }
        public int UserID { get; set; }


    }
}
