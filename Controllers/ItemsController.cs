using Microsoft.AspNetCore.Mvc;
using PostgresApi.DataAccess.Models;
using PostgresApi.DataAccess.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(IRepository<Item> repo)
        {
            _repo = repo;
        }

        private readonly IRepository<Item> _repo;

        // GET: api/<ItemsController>
        [HttpGet]
        public ActionResult<Item[]> Get()
        {
            return _repo.Query().ToArray();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            return _repo.Query().FirstOrDefault(i => i.Id == id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<ActionResult<Item>> Post([FromBody] Item value)
        {
            _repo.Add(value);
            await _repo.SaveAsync();
            return value;
        }

        //// PUT api/<ItemsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ItemsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
