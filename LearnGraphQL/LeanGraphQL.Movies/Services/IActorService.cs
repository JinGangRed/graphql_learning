using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnGraphQL.Movies.Services
{
    public interface IActorService
    {
        Task<Actor> GetActorAsync(int id);


        Task<IEnumerable<Actor>> GetActorsAsync();
    }
}
