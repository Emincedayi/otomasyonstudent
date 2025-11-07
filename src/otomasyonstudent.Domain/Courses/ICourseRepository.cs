using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Courses
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
        Task<List<Course>> GetListAsync(
            string? filterText = null,
            string? title = null,
            string? code = null,
            Guid? teacherId = null,
            bool? isActive = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task DeleteAllAsync(
            string? filterText = null,
            string? title = null,
            string? code = null,
            Guid? teacherId = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string? filterText = null,
            string? title = null,
            string? code = null,
            Guid? teacherId = null,
            CancellationToken cancellationToken = default);
    }
}
