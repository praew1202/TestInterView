using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
       private readonly DemoContext _context;
        public HomeController(DemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fruit>>> GetFruits() {
            return await _context.Fruits.ToListAsync();
        }

        [HttpGet("search")]
        public async Task<List<Fruit>> Search( string name ){
          return  await _context.Fruits.Where(t => t.FruitName.Contains(name)).ToListAsync();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Fruit>> Register(Fruit fruit)
        {
            if (await CheckDat(fruit.FruitName)) return BadRequest("FruitName is Duplicate");
             var id = await _context.Fruits.ToListAsync();
             var _fruit = new Fruit()
            {
                FruitId  = id.Count +1,
                FruitName = fruit.FruitName,
                Img = fruit.Img

            };
            _context.Fruits.Add(_fruit);
            await _context.SaveChangesAsync();
            return fruit;
            
        }
          private async Task<bool> CheckDat(string fruitName)
        {
            return await _context.Fruits.AnyAsync(fruit => fruit.FruitName == fruitName.ToLower());
        }
      
    }
}