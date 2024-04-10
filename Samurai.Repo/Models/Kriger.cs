using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Models
{
    public class Kriger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Kills { get; set; }
        public List<Samurais> Samurais { get; set; }

    }
}
