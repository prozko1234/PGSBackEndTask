using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PGSTask.Web1.Models
{
/// <summary>
/// Model for describing 'Game' entity;
/// </summary>
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required]
        public string Platform { get; set; }

        public string Developer { get; set; }
        // Price for 1 copy.
        [Range(0, 999.99)]
        public float Price { get; set; }
    }
}
