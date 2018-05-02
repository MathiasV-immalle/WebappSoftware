using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace webappSOFT.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new webappSOFTContext(
                serviceProvider.GetRequiredService<DbContextOptions<webappSOFTContext>>()))
            {
                // Look for any movies.
                if (context.Sound.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sound.AddRange(
                     new Sound
                     {
                         Title = "Fireflies",
                         Artist1 = "Owl City",
                         Remix = "Said The Sky",
                         ReleaseDate = DateTime.Parse("2015-12-1"),
                         Genre = "Chill Music",
                     },

                     new Sound
                     {
                         Title = "Exploration Of Space",
                         Artist1 = "Cosmic Gate",
                         ReleaseDate = DateTime.Parse("2010-6-7"),
                         Genre = "Trance Music",
                     },

                     new Sound
                     {
                         Title = "Zombie",
                         Artist1 = "The Cranberries",
                         Remix = "Ran-D",
                         ReleaseDate = DateTime.Parse("2016-12-24"),
                         Genre = "Hardstyle Music",
                     },

                   new Sound
                   {
                       Title = "Ciminally Insane",
                       Artist1 = "Angerfist",
                       Remix = "Radical Redemption",
                       ReleaseDate = DateTime.Parse("2018-1-26"),
                       Genre = "Hardcore Music",
                   },

                   new Sound
                   {
                       Title = "Love Has Gone",
                       Artist1 = "Netsky",
                       ReleaseDate = DateTime.Parse("2012-6-25"),
                       Genre = "Dubstep Music",
                   },

                   new Sound
                   {
                       Title = "How You Remind Me",
                       Artist1 = "Nickelback",
                       Remix = "Mattiv",
                       ReleaseDate = DateTime.Parse("2015-7-10"),
                       Genre = "JumpUp Music",
                   },

                   new Sound
                   {
                       Title = "F.A.C.T.",
                       Artist1 = "Demoxx",
                       Artist2 = "Steeper",
                       ReleaseDate = DateTime.Parse("2018-4-5"),
                       Genre = "Hardstyle Music",
                   },

                   new Sound
                   {
                       Title = "Send Me An Angel",
                       Artist1 = "Mark With A K",
                       Artist2 = "Hard Driver",
                       Remix = "Ratacail",
                       ReleaseDate = DateTime.Parse("2018-4-6"),
                       Genre = "Hardstyle Music",
                   },

                    new Sound
                    {
                        Title = "God Is A Girl",
                        Artist1 = "W&W",
                        Artist2 = "Groove Courage",
                        Remix = "Mystqz",
                        ReleaseDate = DateTime.Parse("2018-4-10"),
                        Genre = "Hardstyle Music",
                    },

                    new Sound
                    {
                        Title = "Reality",
                        Artist1 = "Lost Frequencies",
                        Artist2 = "Janieck Music",
                        ReleaseDate = DateTime.Parse("2015-5-28"),
                        Genre = "EDM music",
                    },

                    new Sound
                    {
                        Title = "Not Fair",
                        Artist1 = "Lily Allen",
                        Remix = "HBz",
                        ReleaseDate = DateTime.Parse("2018-3-14"),
                        Genre = "Bounce Music",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
