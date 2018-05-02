using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webappSOFT.Models
{
    public class Sound
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Artist 1")]
        public string Artist1 { get; set; }

        [Display(Name = "Artist 2")]
        public string Artist2 { get; set; }

        [Display(Name = "Artist 3")]
        public string Artist3 { get; set; }

        [Display(Name = "DJ Remix")]
        public string Remix { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
    }
}
