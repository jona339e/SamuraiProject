using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Interfaces
{
    public interface ICoffeeRepository
    {
        public Task<Coffee> Create(Coffee model);
        public Task<List<Coffee>> GetAll();
        public Task<Coffee> GetByName(string name);
        public Task<Coffee> Update(Coffee model);
    }
}
