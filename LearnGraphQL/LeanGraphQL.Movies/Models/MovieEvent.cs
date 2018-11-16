using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Models
{
    public class MovieEvent
    {
        public MovieEvent()
        {
            Id = new Guid();
        }
        public Guid Id { set; get; }

        public int MovieId { set; get; }

        public string Name { set; get; }

        public DateTime TimeStamp { set; get; }

        public MovieRating MovieRating { set; get; }
    }
}
