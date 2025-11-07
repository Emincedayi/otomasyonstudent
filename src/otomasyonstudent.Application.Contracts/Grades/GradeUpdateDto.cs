using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Grades
{
    public class GradeUpdateDto
    {
        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [StringLength(256)]
        public string? Comment { get; set; }
    }
}
