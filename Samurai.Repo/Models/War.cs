using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Models
{
    public class War
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Viking Vikings { get; set; }
        public Ninja Ninjas { get; set; }

    }
}
