using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webappSOFT.Models
{
    public class SoundGenreViewModel
    {
        public List<Sound> sounds;
        public SelectList genres;
        public string SoundGenre { get; set; }
    }
}
