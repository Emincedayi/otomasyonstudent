using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace otomasyonstudent.Enrollments
{
    public interface IEnrollmentsAppService :
     ICrudAppService<
         EnrollmentDto,
         Guid,
         PagedAndSortedResultRequestDto,
         EnrollmentCreateDto,
         EnrollmentUpdateDto>
    {
    }
}
