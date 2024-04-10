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
    public class KrigerRepository : IKrigerRepository
    {
        private readonly DataContext _context;

        public KrigerRepository(DataContext context)
        {
            _context = context;
        }
        public Kriger Create(Kriger kriger)
        {
            _context.Add(kriger);
            if(_context.SaveChanges() > 1)
            {
                return kriger;
            }
            throw new Exception("Failed to Create Kriger");
        }

        public bool Delete(int id)
        {
            _context.Kriger.FirstOrDefault(i => i.Id == id);
            return _context.SaveChanges() > 1;
        }

        public List<Kriger> GetAll()
        {
            return _context.Kriger.ToList() ?? throw new Exception("No Kriger Found");
        }

        public Kriger GetById(int id)
        {
            return _context.Kriger.FirstOrDefault( i => i.Id == id) ?? throw new Exception("No Kriger Found");

        }

        public Kriger Update(Kriger kriger)
        {
            _context.Kriger.Update(kriger);
            if (_context.SaveChanges() > 1)
            {
                return kriger;
            }
            throw new Exception("Failed to Update Kriger");
            
        }
    }
}
