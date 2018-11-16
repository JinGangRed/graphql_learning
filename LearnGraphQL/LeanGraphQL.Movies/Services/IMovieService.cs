using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnGraphQL.Movies.Services
{
    public interface IMovieService
    {
        Task<Movie> GetMovieAsync(int id);

        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> CreateAsync(Movie movie);
    }
}
