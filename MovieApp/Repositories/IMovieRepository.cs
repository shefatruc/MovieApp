using MovieApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Repositories;

namespace MovieApp.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre);
    }
}