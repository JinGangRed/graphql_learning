using GraphQL.Types;
using LearnGraphQL.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Schema
{
    public class ActorType:ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
