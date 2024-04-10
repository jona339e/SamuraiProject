using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Interfaces
{
    public interface IKrigerRepository
    {
        Kriger Create(Kriger kriger);
        Kriger GetById(int id);
        List<Kriger> GetAll();
        Kriger Update(Kriger kriger);
        bool Delete(int id);
    }
}
