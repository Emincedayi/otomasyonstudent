using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Students
{
    public class StudentWithNavigationProperties
    {
        public Student Student { get; set; } = null!;
        // Örnek: bir student'ın primary teacher veya benzeri ilişki varsa eklenebilir
        // public Teacher? PrimaryTeacher { get; set; }
    }
}
