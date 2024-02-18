using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDictionaryDAL.Model
{
    public class Movie
    {
        public int MovieID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public int Stars { get; set; }
        public string Comments { get; set; }
    }
}
