using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tahaluf.SoundCloud.Core.Data
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }

        public ICollection<Sounds> sound { get; set; }
    }
}
