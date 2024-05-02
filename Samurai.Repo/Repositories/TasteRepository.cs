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
        public Task<Taste> Create(Coffee model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Taste>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
