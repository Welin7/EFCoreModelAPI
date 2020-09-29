using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreModelAPI.Entities
{
    public class Movie
    {
        protected Movie() { }
        public Movie(string namemovie) 
        {
            NameMovie = namemovie;
        }
        public int Id { get; set; }
        public string NameMovie { get; set; }

        public VideoStore VideoStore { get; set; }
        public int VideoStoreId { get; set; }
    }
}
