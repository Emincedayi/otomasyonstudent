using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Grades
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public Guid EnrollmentId { get; set; }
        public decimal Score { get; set; }
        public string? Comment { get; set; }
    }
}
