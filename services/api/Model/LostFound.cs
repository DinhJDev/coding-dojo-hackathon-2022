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
    public class LostFound: ICoord<LostFound>
    {
        [Key]
        public int Id { get; set; }
        public string? From { get; set; }
        public string? Contact { get; set; }
        public string? LostFoundAge { get; set; }
        public string? ContactType { get; set; }
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
