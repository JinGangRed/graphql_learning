using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using LearnGraphQL.Movies.Models;

namespace LearnGraphQL.Movies.Services
{
    public class MovieEventService : IMovieEventService
    {
        public readonly ISubject<MovieEvent> _eventStream = new ReplaySubject<MovieEvent>();
        public ConcurrentStack<MovieEvent> AllEvents { get; }
        public MovieEventService()
        {
            AllEvents = new ConcurrentStack<MovieEvent>();
        }

        public void AddError(Exception ex)
        {
            _eventStream.OnError(ex);
        }

        public MovieEvent AddEvent(MovieEvent movieEvent)
        {
            AllEvents.Push(movieEvent);
            _eventStream.OnNext(movieEvent);
            return movieEvent;
        }

        public IObservable<MovieEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}
