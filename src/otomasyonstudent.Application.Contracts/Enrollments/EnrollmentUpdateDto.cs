using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Enrollments
{
    public class EnrollmentUpdateDto
    {
        [Range(0, 100)]
        public int Absences { get; set; }
    }
}
