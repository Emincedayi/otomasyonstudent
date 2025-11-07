using otomasyonstudent.Courses;
using otomasyonstudent.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Students
{
    public class StudentWithNavigationPropertiesDto
    {
        public StudentDto Student { get; set; } = null!;
        public List<CourseDto> Courses { get; set; } = new();
        public List<GradeDto> Grades { get; set; } = new();
    }
}
