using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace otomasyonstudent.Students
{
    public class StudentDto : EntityDto<Guid>
    {
        public string StudentNo { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

            //[Required]
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
