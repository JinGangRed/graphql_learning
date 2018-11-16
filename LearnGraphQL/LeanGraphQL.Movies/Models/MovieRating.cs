using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQL.Movies.Models
{
    [Flags]
    public enum MovieRating
    {
        Unrated = 0,
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
        NC = 5,
    }
}
