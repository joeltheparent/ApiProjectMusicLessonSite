using System.ComponentModel.DataAnnotations;

namespace MusicLessonSiteApi.Models
{
    public class Course
    {
        public Course() { }

        public int Id { get; set; }
        [Required]
        public string? Instrument { get; set; }
        [Required]
        public string? PlayerLevel { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}

