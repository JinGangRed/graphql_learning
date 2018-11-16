using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MovieEventType:ObjectGraphType<MovieEvent>
    {
        public MovieEventType()
        {
            Name = "MovieEvent";
            Field(e => e.Id,type: typeof(IdGraphType));
            Field(e => e.MovieId);
            Field(e => e.Name);
            Field(e => e.TimeStamp);
            Field(e => e.MovieRating, type: typeof(MovieRatingEnum));
        }
    }
}
