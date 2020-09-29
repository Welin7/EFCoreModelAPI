using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreModelAPI.Entities
{
    public class VideoStore
    {
        public VideoStore() { }

        public VideoStore(int id, string namevideostore) 
        {
            Id = id;
            NameVideoStore = namevideostore;
            Active = true;
        }

        public VideoStore(string namevideostore)
        {
            NameVideoStore = namevideostore;
            Active = true;
        }
        public int Id { get; set; }
        public string NameVideoStore { get; set; }
        public bool Active { get; set; }
        public Director Director { get; set; }
        public List<Movie> Movies { get; set; }

        public void AddMovie(string NameMovie)
        {
            Movies.Add(new Movie(NameMovie));
        }

        public void AddDirector(string NameDirector)
        {
            Director = new Director(NameDirector,"Action");
        }
    }
}
