using GameStore.FrontEnd.Datas;
using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Services
{
    public class GameService
    {
        public GameService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public void AddGame(GameDetails game)
        {
            Context.Games.Add(game);
            Context.SaveChanges();
        }

        public void RemoveGame(GameDetails game) {
            Context.Games.Remove(game);
            Context.SaveChanges();
        }

        public void UpdateGame(GameDetails game)
        {
            Context.Games.Update(game);
            Context.SaveChanges();
        }

        public GameDetails? GetGame(int id)
        {
            return Context.Games.Find(id);
        }

        public async Task<List<GameDetails>> GetGamesAsync()
        {
            //await Task.Delay(5000);
            return  await Task.FromResult(Context.Games.ToList());
        }

        public IEnumerable<GameDetails> GetGamesByGenre(int genreId)
        {
            return Context.Games.Where(g => g.GenreId == genreId.ToString()).ToList();
        }

        public async Task DeleteGameByIdAsync(int Id)
        {
            GameDetails? game = Context.Games.Find(Id);

            await Task.FromResult(Context.Games.Remove(game));

        }

    }
}
