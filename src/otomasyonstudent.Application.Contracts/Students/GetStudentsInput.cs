using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace otomasyonstudent.Students
{
    public class GetStudentsInput : PagedAndSortedResultRequestDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
