﻿using EcommerceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;

        public BrandController(BrandContext dbContext){
            _dbContext= dbContext;
}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands()
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brands>> GetBrands(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brands>> PostBrands(Brands brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new {id = brand.ID},brand);

        }

        [HttpPut]
        public async Task<IActionResult> PutBrand(int id, Brands brand)
        {
            if (id != brand.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;
            try { await _dbContext.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { 
            if (!BrandAvailable(id)){
                    return NotFound();
                }
                else
                {
                    throw;
                }
                    }
            return Ok();
        }

        private bool BrandAvailable(int id)
        {
            return (_dbContext.Brands?.Any(x => x.ID == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrands(int id)
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }

            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        
    }
}
