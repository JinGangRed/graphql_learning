using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using LearnGraphQL.Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MoviesMutation : ObjectGraphType
    {
        public MoviesMutation(IMovieService movieService)
        {
            Name = "Mutation";
            FieldAsync<MovieType>("createMovie",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>> {
                    Name = "movie" }),
                resolve: async context =>
                {
                    var movieInput = context.GetArgument<MovieInput>("movie");
                    var movies = await movieService.GetMoviesAsync();
                    var maxId = movies.Select(x => x.Id).Max();

                    var movie = new Movie
                    {
                        Id = ++maxId,
                        Name = movieInput.Name,
                        Company = movieInput.Company,
                        ActorID = movieInput.ActorID,
                        MovieRating = movieInput.MovieRating,
                        ReleaseDate = movieInput.ReleaseDate
                    };
                    var result = await movieService.CreateAsync(movie);
                    return result;
                });
        }
    }
}
