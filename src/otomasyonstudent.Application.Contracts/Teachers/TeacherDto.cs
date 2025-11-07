using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace otomasyonstudent.Teachers
{
    public class TeacherDto //:EntityDto<Guid>
    {
       
        public string FirstName { get; private set; }

      
        public string LastName { get; private set; }

        public EnumGender Gender { get; private set; }

        public string? Email { get; private set; }

        public string? PhoneNumber { get; private set; }
    }
}
