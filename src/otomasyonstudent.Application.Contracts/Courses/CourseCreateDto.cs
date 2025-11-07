using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Courses
{
    public class CourseCreateDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = null!;

        [StringLength(512)]
        public string? Description { get; set; }

        [Required]
        public Guid TeacherId { get; set; }
    }
}
