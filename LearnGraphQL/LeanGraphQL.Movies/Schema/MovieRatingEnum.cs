using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MovieRatingEnum: EnumerationGraphType<MovieRating>
    {
        public MovieRatingEnum()
        {
            Name = "MovieRating";
            Description = "电影评级";

            AddValue(MovieRating.G.ToString(), "G", MovieRating.G);

            AddValue(MovieRating.PG.ToString(), "PG", MovieRating.PG);
            AddValue(MovieRating.PG13.ToString(), "PG13", MovieRating.PG13);
            AddValue(MovieRating.R.ToString(), "R", MovieRating.R);
            AddValue(MovieRating.Unrated.ToString(), "Unrated", MovieRating.Unrated);
            AddValue(MovieRating.NC.ToString(), "NC", MovieRating.NC);
        }
    }
}
