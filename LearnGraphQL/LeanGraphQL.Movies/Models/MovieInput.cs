using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Models
{
    public class MovieInput
    {
        public string Name { set; get; }
        public DateTime ReleaseDate { set; get; }
        public string Company { set; get; }
        public int ActorID { set; get; }
        public MovieRating MovieRating { set; get; }
    }
}
