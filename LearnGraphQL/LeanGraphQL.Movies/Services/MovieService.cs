using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnGraphQL.Movies.Models;

namespace LearnGraphQL.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IList<Movie> _movies;
        private readonly IMovieEventService movieEventService;

        public MovieService(IMovieEventService movieEventService)
        {
            #region Movies
            _movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Movie1",
                    ActorID = 1,
                    Company = "Company1",
                    MovieRating = MovieRating.G,
                    ReleaseDate = new DateTime(1994,1,1)
                },
                new Movie
                {
                    Id = 2,
                    Name = "Movie2",
                    ActorID = 2,
                    Company = "Company2",
                    MovieRating = MovieRating.NC,
                    ReleaseDate = new DateTime(1994,1,2)
                },
                new Movie
                {
                    Id = 3,
                    Name = "Movie3",
                    ActorID = 3,
                    Company = "Company3",
                    MovieRating = MovieRating.PG,
                    ReleaseDate = new DateTime(1994,1,3)
                },
                new Movie
                {
                    Id = 4,
                    Name = "Movie4",
                    ActorID = 4,
                    Company = "Company4",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(1994,1,4)
                },
                new Movie
                {
                    Id = 5,
                    Name = "Movie5",
                    ActorID = 5,
                    Company = "Company5",
                    MovieRating = MovieRating.R,
                    ReleaseDate = new DateTime(1994,1,5)
                },
            };
            this.movieEventService = movieEventService;
            #endregion
        }

        public Task<Movie> CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            var movieEvent = new MovieEvent
            {
                Name = $"Add Movie",
                MovieId = movie.Id,
                TimeStamp = DateTime.Now,
                MovieRating = movie.MovieRating
            };
            movieEventService.AddEvent(movieEvent);
            return Task.FromResult(movie);
        }

        public Task<Movie> GetMovieAsync(int id)
        {
            var movie = _movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                throw new ArgumentException(String.Format("Movie ID {0} 不正确", id));
            }
            return Task.FromResult(movie);
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }
    }
}
