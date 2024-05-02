using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Models
{
    public class CoffeeTaste
    {
        public int TasteId { get; set; }
        public Taste Taste { get; set; }
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; }
    }
}
