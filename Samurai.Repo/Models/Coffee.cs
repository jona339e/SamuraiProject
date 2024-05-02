using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Taste> Taste { get; set; }

    }
}
