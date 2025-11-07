using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Attendances
{
    public interface IAttendanceRepository : IRepository<Attendance, Guid>
    {
        Task<List<Attendance>> GetListAsync(
            Guid? enrollmentId = null,
            Guid? studentId = null,
            Guid? courseId = null,
            DateTime? from = null,
            DateTime? to = null,
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
