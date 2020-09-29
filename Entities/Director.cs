using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreModelAPI.Entities
{
    public class Director
    {
        public Director() { }
        public Director(string namedirector, string category) 
        {
            NameDirector = namedirector;
            Category = category;
        }
        public int Id { get; set; }
        public string NameDirector { get; set; }
        public string Category { get; set; }
        public int MovieStoreId { get; set; }
    }
}
