using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.New.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace DotNetCore.New.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{v:apiVersion}/[controller]")]
    
   // [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly MoviesDbContext _dbContext;
        public MoviesController(ILogger<MoviesController> logger, MoviesDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }
        [HttpGet]
        [Route("Who")]
        [MapToApiVersion("1.0")]

        public IActionResult Who()
        {
            return Ok("Movies v1 API Controller");
        }

        [HttpGet]
        [Route("")]
        [Produces(typeof(IEnumerable<Movie>))]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            IEnumerable<Movie> list = _dbContext.Movies;
            list = list.OrderBy((x) => x.Title);
            return Ok(list);
       }

        [HttpGet]
        [Route("{id:int}")]
        [Produces(typeof(Movie))]
        [MapToApiVersion("1.0")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Movies.Find(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            } 
        }

        [HttpPost]
        [Route("Create")]
        [MapToApiVersion("1.0")]
        public IActionResult Post([FromBody] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        [MapToApiVersion("1.0")]
        public IActionResult Put([FromBody] Movie movie, int id)
        {
            var entity = _dbContext.Movies.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = movie.Title;
            entity.NumberInStock = movie.NumberInStock;
            entity.Liked = movie.Liked;
            entity.Genre = movie.Genre;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        [MapToApiVersion("1.0")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Movies.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}
