using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Students
{
    public class StudentCreateDto
    {
        public string StudentNo { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public EnumGender Gender { get; set; } 

      //  [Required]
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
