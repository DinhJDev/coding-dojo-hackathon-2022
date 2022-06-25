using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Core
{
    public class HotZone
    {
        [Key]
        public int Id { get; set; }

        public int? DangerLevel { get; set; }
        
        public string? ZoneAge { get; set; }
        [Required]
        public string? Lat { get; set; }
        [Required]
        public string? Lon { get; set; }
        
        public bool IsHidden
        {
            get
            {
                return IsHidden;
            }
            set
            {
                if (UpdatedAt > DateTime.UtcNow.AddHours(12))
                {
                    IsHidden = true;
                }
                else
                {
                    IsHidden = false;
                }
            }
        }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
