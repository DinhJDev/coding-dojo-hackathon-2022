using System.ComponentModel.DataAnnotations;

namespace Hackathon.Interface
{
    public interface ICoord<T>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double? Lat { get; set; }
        [Required]
        public double? Lng { get; set; }

        public bool IsHidden => UpdatedAt > DateTime.UtcNow.AddHours(-12);
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
