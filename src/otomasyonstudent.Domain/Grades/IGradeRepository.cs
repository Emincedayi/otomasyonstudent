using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Grades
{
    public interface IGradeRepository : IRepository<Grade, Guid>
    {
        Task<List<Grade>> GetListAsync(
            Guid? enrollmentId = null,
            Guid? studentId = null,
            Guid? courseId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task DeleteAllAsync(
            Guid? enrollmentId = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? enrollmentId = null,
            CancellationToken cancellationToken = default);
    }
}
