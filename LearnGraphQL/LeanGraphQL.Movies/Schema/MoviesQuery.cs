using GraphQL.Types;
using LearnGraphQL.Movies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MoviesQuery: ObjectGraphType
    {
        public MoviesQuery(IMovieService movieService)
        {
            Name = "Query";
            Field<ListGraphType<MovieType>>("movies", resolve: context => movieService.GetMoviesAsync());
        }
    }
}
