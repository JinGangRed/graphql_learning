using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using LearnGraphQL.Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MoviesSubscription: ObjectGraphType
    {
        private readonly IMovieEventService movieEventService;

        public MoviesSubscription(IMovieEventService movieEventService)
        {
            this.movieEventService = movieEventService;
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "movieEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<MovieRatingEnum>>{
                    Name = "movieRatings"
                }),
                Type = typeof(MovieEventType),
                Resolver = new FuncFieldResolver<MovieEvent>(Resolver),
                Subscriber = new EventStreamResolver<MovieEvent>(Subscribe)

            });
        }

        private IObservable<MovieEvent> Subscribe(ResolveEventStreamContext context)
        {
            var ratingList = context.GetArgument<IList<MovieRating>>("movieRations", new List<MovieRating>());
            if (ratingList.Any())
            {
                MovieRating ratings = 0;
                foreach (var item in ratingList)
                {
                    ratings = item | item;
                }
                return movieEventService.EventStream().Where(e => (e.MovieRating & ratings) == e.MovieRating);
            }
            else
            {
                return movieEventService.EventStream();
            }
        }

        private MovieEvent Resolver(ResolveFieldContext context)
        {
            var movieEvent = context.Source as MovieEvent;
            return movieEvent;
        }
    }
}
