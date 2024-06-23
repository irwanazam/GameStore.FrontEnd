using GameStore.FrontEnd.Datas;
using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Services
{
    public class GenreService
    {
        public GenreService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }


        public void AddGenre(Genre genre)
        {
            Context.Genres.Add(genre);
            Context.SaveChanges();
        }

        public void RemoveGenre(Genre genre)
        {
            Context.Genres.Remove(genre);
            Context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            Context.Genres.Update(genre);
            Context.SaveChanges();
        }

        public Genre? GetGenre(int id)
        {
            return Context.Genres.Find(id);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return Context.Genres.ToList();
        }

        public IEnumerable<Genre> GetGenresByGenre(int genreId)
        {
            return Context.Genres.Where(g => g.Id == genreId).ToList();
        }
    }
}
