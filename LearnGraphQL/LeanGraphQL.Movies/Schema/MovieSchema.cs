using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class MovieSchema:GraphQL.Types.Schema
    {
        public MovieSchema(IDependencyResolver dependencyResolver,
            MoviesQuery moviesQuery, 
            MoviesMutation moviesMutation,
            MoviesSubscription moviesSubscription)
        {
            DependencyResolver = dependencyResolver;
            Query = moviesQuery;

            Mutation = moviesMutation;
            Subscription = moviesSubscription;
        }
    }
}
