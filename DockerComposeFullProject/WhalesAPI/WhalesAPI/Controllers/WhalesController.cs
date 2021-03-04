
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WhalesAPI.Models;

namespace WhalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WhalesController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public WhalesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Whale> Get()
        {
            return dbContext.GetAllWhales();
        }

        [HttpGet]
        public IEnumerable<Whale> PostAWhale()
        {
            return dbContext.AddRandom();
        }

        [HttpGet]
        public IEnumerable<Whale> Reset()
        {
            dbContext.RemoveAll();
            return dbContext.Seed();
        }

        [HttpGet]
        public IActionResult Clear()
        {
            dbContext.RemoveAll();
            return Ok();
        }
    }
}



