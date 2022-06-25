using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Core
{
    public class LostFound
    {
        [Key]
        public int Id { get; set; }
        public string? From { get; set; }
        public string? Contact { get; set; }
        [Required]
        public string? LostFoundAge { get; set; }
        public string? ContactType { get; set; }
        [Required]
        public string? Lat { get; set; }
        [Required]
        public string? Lon { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
