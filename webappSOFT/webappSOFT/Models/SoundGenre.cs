using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace webappSOFT.Models
{
    public class SoundGenre
    {
        public List<Sound> sounds;
        public SelectList genres;
        public string soundGenre { get; set; }
    }
}
