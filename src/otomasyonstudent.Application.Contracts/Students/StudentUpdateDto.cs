using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Students
{
    public class StudentUpdateDto
    {
        /*public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }*/
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public EnumGender Gender { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? StudentNo { get; set; }
    }
}
