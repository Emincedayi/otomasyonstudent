using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace otomasyonstudent.Courses
{
    public class CourseDto : EntityDto<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid TeacherId { get; set; }
      //  public CourseStatus Status { get; set; }
    }
}
