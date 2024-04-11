using Samurai.Repo.DTOs;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Services
{
    public class MappingService: IMappingService
    {
        public Samurais SamuraiDtoToSamurais(SamuraiDto Samurai)
        {
            Samurais mappedSamurai = new()
            {
                Name = Samurai.Name,
                Description = Samurai.Description,
                Age = Samurai.Age
            };

            return mappedSamurai;
        }
    }
}
