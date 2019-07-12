using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class TeamViewModel
    {
        public TeamViewModel() { }
        public long Id { get; set; }

        public string TeamName { get; set; }
        public string Location { get; set; }
        public string Mascot { get; set; }
    }
}
