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
        bool Create(Samurais samurai);
        Samurais GetById(int id);
        List<Samurais> GetAll();
        bool Update(Samurais samurai);
        bool Delete(Samurais samurais);

    }
}
