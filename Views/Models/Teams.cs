using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace F1Championship.Models
{
    public class Teams
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? TeamName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Headquarters { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? TeamPrincipal { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Chassis { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Engine { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Drivers { get; set; }

    }

}

