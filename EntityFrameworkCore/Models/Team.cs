using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Models
{
    public class Team
    {
        public Team() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Mascot { get; set; }
        public string TeamName { get; set; }
        public string Location { get; set; }
    }
}