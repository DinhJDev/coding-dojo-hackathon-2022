using Hackathon.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Core
{
    public class HotZone : ICoord<HotZone>
    {
        [Key]
        public int Id { get; set; }

        public int? DangerLevel { get; set; }
        
        public string? ZoneAge { get; set; }
        [Required]
        public double? Lat { get; set; }
        [Required]
        public double? Lng { get; set; }
        [NotMapped]

        public bool IsHidden => UpdatedAt > DateTime.UtcNow.AddHours(-12);
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
