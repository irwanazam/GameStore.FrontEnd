using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Clients;

public class GenreClient
{
    private readonly Genre[] genres = new[]
    {
        new Genre { Id = 1, Name = "Action-adventure" },
        new Genre { Id = 2, Name = "Platformer" },
        new Genre { Id = 3, Name = "Racing" },
        new Genre { Id = 4, Name = "Shooter" },
        new Genre { Id = 5, Name = "Life simulation" }
    };

    public Task<List<Genre>> GetGenresAsync()
    {
        return Task.FromResult(genres.ToList());
    }
}
