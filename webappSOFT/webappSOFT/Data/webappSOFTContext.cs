using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webappSOFT.Models
{
    public class webappSOFTContext : DbContext
    {
        public webappSOFTContext (DbContextOptions<webappSOFTContext> options)
            : base(options)
        {
        }

        public DbSet<webappSOFT.Models.Sound> Sound { get; set; }
    }
}
