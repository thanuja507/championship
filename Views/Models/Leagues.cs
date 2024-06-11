using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace F1Championship.Models
{
    public class Leagues
    {
        public int Id { get; set; }
        public int TeamId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Team { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? League { get; set; }

    }

}

