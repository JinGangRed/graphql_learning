using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnGraphQL.Movies.Models;

namespace LearnGraphQL.Movies.Services
{
    public class ActorService : IActorService
    {
        private readonly IList<Actor> _actors;

        public ActorService()
        {
            _actors = new List<Actor>
            {
                new Actor{Id = 1,Name = "Actor1"},
                new Actor{Id = 2,Name = "Actor2"},
                new Actor{Id = 3,Name = "Actor3"},
                new Actor{Id = 4,Name = "Actor4"},
                new Actor{Id = 5,Name = "Actor5"},
            };
        }
        public Task<Actor> GetActorAsync(int id)
        {
            return Task.FromResult(_actors.SingleOrDefault(a => a.Id == id));
        }

        public Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return Task.FromResult(_actors.AsEnumerable());
        }
    }
}
