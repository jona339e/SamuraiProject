using Microsoft.EntityFrameworkCore;
using Samurai.Repo.Data;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly DataContext _context;
        public CoffeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Coffee> Create(Coffee model)
        {
            var result = await _context.Coffees.AddAsync(model);
            if (_context.SaveChanges() >= 0)
                return result.Entity;
            throw new Exception("Could not create coffee");
        }

        public async Task<List<Coffee>> GetAll()
        {
            return await _context.Coffees.Include(x => x.CoffeeTastes).ThenInclude(x => x.Taste).ToListAsync();
        }

        public async Task<Coffee> GetByName(string name)
        {
            // return null if no coffee was found
            return await _context.Coffees.FirstOrDefaultAsync(x => x.Name == name) ?? null;


        }

        public async Task<Taste> GetTaste(int id)
        {
            return await _context.Taste.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Coffee> Update(Coffee model)
        {
            var result = _context.Coffees.Update(model);
            if (_context.SaveChanges() >= 0)
                return result.Entity;

            throw new Exception("Could not update coffee");
        }
    }
}
