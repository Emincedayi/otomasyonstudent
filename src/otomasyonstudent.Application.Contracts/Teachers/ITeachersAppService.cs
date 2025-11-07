using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace otomasyonstudent.Teachers
{
    public interface ITeachersAppService :
     ICrudAppService<
         TeacherDto,
         Guid,
         PagedAndSortedResultRequestDto,
         TeacherCreateDto,
         TeacherUpdateDto>
    {
    }
}
