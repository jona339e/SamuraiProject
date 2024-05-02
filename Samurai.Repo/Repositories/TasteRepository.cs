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
    public class TasteRepository : ITasteRepository
    {
        private readonly DataContext _context;
        public TasteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Taste> Create(Taste model)
        {
            var result = await _context.Taste.AddAsync(model);
            if (_context.SaveChanges() >= 0)
                return result.Entity;
            throw new Exception("Could not create taste");
        }

        public async Task<List<Taste>> GetAll()
        {
            return await _context.Taste.ToListAsync();
        }

        public async Task<Taste> GetByName(string name)
        {
            return await _context.Taste.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<Taste> Update(Taste model)
        {
            var result = _context.Taste.Update(model);
            if (_context.SaveChanges() >= 0)
                return Task.FromResult(result.Entity);
            throw new Exception("Could not update taste");
        }
    }
}
