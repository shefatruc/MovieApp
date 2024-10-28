using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Movie> _dbSet;

        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Movie>();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _dbSet.Where(m => m.Genre == genre).ToListAsync();
        }
    }
}
