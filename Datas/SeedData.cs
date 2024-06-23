using Microsoft.EntityFrameworkCore;

namespace GameStore.FrontEnd.Datas
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Seed your database here
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                foreach (var g in context.Games)
                {
                    context.Games.Remove(g);
                }

                foreach (var g in context.Genres)
                {
                    context.Genres.Remove(g);
                }

                context.SaveChanges();

                context.Genres.AddRange(
                    new Models.Genre { Id = 1, Name="Action" },
                    new Models.Genre { Id = 2, Name = "Games" },
                    new Models.Genre { Id = 3, Name = "Movies" }
                    );


                context.Games.AddRange(
                    new Models.GameDetails
                    {
                        Name = "Super Mario Bros.",
                        GenreId = "1",
                        GenreName = "Action",
                        Price = 29.99m,
                        ReleaseDate = new DateOnly(1985, 9, 13)
                    },
                    new Models.GameDetails
                    {
                        Name = "The Legend of Zelda",
                        GenreId = "1",
                        GenreName = "Action",
                        Price = 39.99m,
                        ReleaseDate = new DateOnly(1986, 2, 21)
                    },
                    new Models.GameDetails
                    {
                        Name = "Minecraft",
                        GenreId = "2",
                        GenreName = "Games",
                        Price = 19.99m,
                        ReleaseDate = new DateOnly(2011, 11, 18)
                    },
                    new Models.GameDetails
                    {
                        Name = "Grand Theft Auto V",
                        GenreId = "3",
                        GenreName = "Movies",
                        Price = 59.99m,
                        ReleaseDate = new DateOnly(2013, 9, 17)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
