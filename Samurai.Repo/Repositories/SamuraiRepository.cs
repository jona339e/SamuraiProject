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
    public class SamuraiRepository : ISamuraiRepository
    {
        private readonly DataContext _context;
        public SamuraiRepository(DataContext context)
        {
            _context = context;
        }
        public bool Create(Samurais samurai)
        {
            _context.Add(samurai);
            return Save();
        }

        public bool Delete(Samurais samurai)
        {
            _context.Samurais.Remove(samurai);
            return Save();
        }

        public Samurais GetById(int id)
        {
            return _context.Samurais.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Samurais samurai)
        {
            _context.Update(samurai);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public List<Samurais> GetAll()
        {
            return _context.Samurais.ToList();
        }

        public bool DeleteTest(TestModel model)
        {
            _context.TestModels.Remove(model);
            return Save();
        }
    }
}
