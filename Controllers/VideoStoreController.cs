using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreModelAPI.Entities;
using EFCoreModelAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelAPI.Controllers
{
    [Route("api/[controller]")]
    public class VideoStoreController : ControllerBase
    {
        private readonly EFCoreAPIDbContext _efCoreApiDbContext;
        public VideoStoreController(EFCoreAPIDbContext efCoreApiDbContext)
        {
            _efCoreApiDbContext = efCoreApiDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var videoStore = new VideoStore("Video Store Good Times");
            _efCoreApiDbContext.VideoStores.Add(videoStore);
            _efCoreApiDbContext.SaveChanges();
            return Ok(videoStore);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var videoStore = _efCoreApiDbContext.VideoStores
                .Include(m => m.Movies)
                .Include(m => m.Director)
                .SingleOrDefault(m => m.Id == id);
            return Ok(videoStore);
        }

        [HttpGet("{id}/popular")]
        public IActionResult Post(int id)
        {
            var videoStore = _efCoreApiDbContext.VideoStores
                .Include(m => m.Movies)
                .Include(m => m.Director)
                .SingleOrDefault(m => m.Id == id);

            videoStore.AddMovie("Era uma vez em Hollywood");
            videoStore.AddDirector("Quentin Tarantino");
            _efCoreApiDbContext.SaveChanges();
            return Ok(videoStore);
        }
    }
}
