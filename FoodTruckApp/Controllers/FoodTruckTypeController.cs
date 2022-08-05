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
    public class FoodTruckTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodTruckTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FoodTruckType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTruckType>>> GetFoodTruckTypes()
        {
          if (_context.FoodTruckTypes == null)
          {
              return NotFound();
          }
            return await _context.FoodTruckTypes.ToListAsync();
        }

        // GET: api/FoodTruckType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodTruckType>> GetFoodTruckType(int id)
        {
          if (_context.FoodTruckTypes == null)
          {
              return NotFound();
          }
            var foodTruckType = await _context.FoodTruckTypes.FindAsync(id);

            if (foodTruckType == null)
            {
                return NotFound();
            }

            return foodTruckType;
        }

        // PUT: api/FoodTruckType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodTruckType(int id, FoodTruckType foodTruckType)
        {
            if (id != foodTruckType.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodTruckType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTruckTypeExists(id))
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

        // POST: api/FoodTruckType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodTruckType>> PostFoodTruckType(FoodTruckType foodTruckType)
        {
          if (_context.FoodTruckTypes == null)
          {
              return Problem("Entity set 'DataContext.FoodTruckTypes'  is null.");
          }
            _context.FoodTruckTypes.Add(foodTruckType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodTruckType", new { id = foodTruckType.Id }, foodTruckType);
        }

        // DELETE: api/FoodTruckType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodTruckType(int id)
        {
            if (_context.FoodTruckTypes == null)
            {
                return NotFound();
            }
            var foodTruckType = await _context.FoodTruckTypes.FindAsync(id);
            if (foodTruckType == null)
            {
                return NotFound();
            }

            _context.FoodTruckTypes.Remove(foodTruckType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodTruckTypeExists(int id)
        {
            return (_context.FoodTruckTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
