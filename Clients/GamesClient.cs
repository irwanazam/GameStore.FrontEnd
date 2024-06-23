using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Clients;

public class GamesClient
{
    private List<GameSummary>? games;

    public GamesClient()
    {
        if (games == null)
        {
            games = new List<GameSummary>();
            InitGames();
        }

    }

    private void InitGames()
    {
        games = new()
        {
            new GameSummary
            {
                Id = 1,
                Name = "The Legend of Zelda: Breath of the Wild",
                Genre = "Action-adventure",
                Price = 59.99m,
                ReleaseDate = new DateOnly(2017, 3, 3)
            },
            new GameSummary
            {
                Id = 2,
                Name = "Super Mario Odyssey",
                Genre = "Platformer",
                Price = 59.99m,
                ReleaseDate = new DateOnly(2017, 10, 27)
            },
            new GameSummary
            {
                Id = 3,
                Name = "Mario Kart 8 Deluxe",
                Genre = "Racing",
                Price = 59.99m,
                ReleaseDate = new DateOnly(2017, 4, 28)
            },
            new GameSummary
            {
                Id = 4,
                Name = "Splatoon 2",
                Genre = "Shooter",
                Price = 59.99m,
                ReleaseDate = new DateOnly(2017, 7, 21)
            },
            new GameSummary
            {
                Id = 5,
                Name = "Animal Crossing: New Horizons",
                Genre = "Life simulation",
                Price = 59.99m,
                ReleaseDate = new DateOnly(2020, 3, 20)
            }
        };

    }

    public Task<List<GameSummary>?> GetGamesAsync()
    {
        return Task.FromResult(games);
    }

    public void AddGame(GameDetails game)
    {
        var genreClient = new GenreClient(); // Assuming GenreClient is the class that provides genre-related functionality.
        
        var genre = genreClient.GetGenresAsync().Result.Single(g => g.Id.ToString() == game.GenreId);
        
        games?.Add(new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        });
    }

    public void UpdateGame(GameDetails game)
    {
        GameSummary? existingGame = games?.Single(g => g.Id == game.Id);

        ArgumentNullException.ThrowIfNull(existingGame, nameof(existingGame));

        var genreClient = new GenreClient();

        var genre = genreClient.GetGenresAsync().Result.Single(g => g.Id.ToString() == game.GenreId);

        existingGame.Name = game.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        GameSummary? game = games?.Single(g => g.Id == id);

        ArgumentNullException.ThrowIfNull(game, nameof(game));

        games?.Remove(game);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary? game = games?.Single(g => g.Id == id);

        ArgumentNullException.ThrowIfNull(game, nameof(game));

        var genreClient = new GenreClient();

        var genre = genreClient.GetGenresAsync().Result.Single(g => g.Name.ToString() == game.Genre);

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}
