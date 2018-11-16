using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using LearnGraphQL.Movies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MovieType: ObjectGraphType<Movie>
    {
        public MovieType(IActorService actorService)
        {
            Name = "Movie";
            Description = "电影类型";
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorID);


            Field<ActorType>("actor", resolve: context => actorService.GetActorAsync(context.Source.ActorID));
            Field<MovieRatingEnum>("movieRatings", resolve: context => context.Source.MovieRating);

        }
    }
}
