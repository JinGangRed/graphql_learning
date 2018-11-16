using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Services
{
    public interface IMovieEventService
    {
        ConcurrentStack<MovieEvent> AllEvents { get; }

        MovieEvent AddEvent(MovieEvent movieEvent);

        void AddError(Exception ex);

        IObservable<MovieEvent> EventStream();

    }
}
