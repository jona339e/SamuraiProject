using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Interfaces
{
    public interface ISamuraiRepository
    {
        public bool Create(Samurais samurai);
        public Samurais Read(int id);
        public bool Update(Samurais samurai);
        public bool Delete(Samurais samurais);

    }
}
