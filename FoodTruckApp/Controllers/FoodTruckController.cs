using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTruckAPI;
using FoodTruckAPI.Data;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodTruckController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FoodTruck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTruck>>> GetFoodTrucks()
        {
          if (_context.FoodTrucks == null)
          {
              return NotFound();
          }
            return await _context.FoodTrucks.ToListAsync();
        }

        // GET: api/FoodTruck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodTruck>> GetFoodTruck(int id)
        {
          if (_context.FoodTrucks == null)
          {
              return NotFound();
          }
            var foodTruck = await _context.FoodTrucks.FindAsync(id);

            if (foodTruck == null)
            {
                return NotFound();
            }

            return foodTruck;
        }

        // PUT: api/FoodTruck/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodTruck(int id, FoodTruck foodTruck)
        {
            if (id != foodTruck.id)
            {
                return BadRequest();
            }

            _context.Entry(foodTruck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTruckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodTruck
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodTruck>> PostFoodTruck(FoodTruck foodTruck)
        {
          if (_context.FoodTrucks == null)
          {
              return Problem("Entity set 'DataContext.FoodTrucks'  is null.");
          }
            _context.FoodTrucks.Add(foodTruck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodTruck", new { id = foodTruck.id }, foodTruck);
        }

        // DELETE: api/FoodTruck/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodTruck(int id)
        {
            if (_context.FoodTrucks == null)
            {
                return NotFound();
            }
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            _context.FoodTrucks.Remove(foodTruck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodTruckExists(int id)
        {
            return (_context.FoodTrucks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
