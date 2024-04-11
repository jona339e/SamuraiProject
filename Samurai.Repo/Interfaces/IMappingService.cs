using Samurai.Repo.DTOs;
using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Interfaces
{
    public interface IMappingService
    {
        Samurais SamuraiDtoToSamurais(SamuraiDto Samurai);
    }
}
