using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MovieInputType:InputObjectGraphType<MovieInput>
    {
        public MovieInputType()
        {
            Name = "MovieInput";
            Field(x => x.Name);
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorID);
            Field(x => x.MovieRating,type: typeof(MovieRatingEnum));
        }
    }
}
