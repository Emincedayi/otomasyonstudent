using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Enrollments
{
    public interface IEnrollmentRepository : IRepository<Enrollment, Guid>
    {
        Task<List<Enrollment>> GetListAsync(
            Guid? studentId = null,
            Guid? courseId = null,
            bool? isActive = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task<Enrollment> GetByStudentAndCourseAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);

        Task DeleteAllAsync(
            Guid? studentId = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? studentId = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default);
    }
}
