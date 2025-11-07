using otomasyonstudent.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace otomasyonstudent.Courses;


 public interface ICoursesAppService :
        ICrudAppService<
            CourseDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CourseCreateDto,
            CourseUpdateDto>
{ 
}



