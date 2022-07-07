using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.SoundCloud.Core.DTO
{
    public class purchaseDTO
    {
        public int CCV { get; set; }
        public int VisaID { get; set; }
        public string ExpireDate { get; set; }
        public string Expiredyear { get; set; }
        public int SoundID { get; set; }
        public int UserID { get; set; }
    }
}
