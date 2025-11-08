using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace otomasyonstudent.Students
{
    public interface IStudentsAppService :
        ICrudAppService<
            StudentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            StudentCreateDto,
            StudentUpdateDto>
    {
    }
}
