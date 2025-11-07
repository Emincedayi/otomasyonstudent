using Microsoft.EntityFrameworkCore;
using otomasyonstudent.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace otomasyonstudent.Enrollments
{
    public class EfCoreEnrollmentRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
         : EfCoreRepository<otomasyonstudentDbContext, Enrollment, Guid>(dbContextProvider), IEnrollmentRepository
    {
        public async Task<List<Enrollment>> GetListAsync(Guid? studentId = null, Guid? courseId = null, bool? isActive = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync());
            query = query
                .WhereIf(studentId.HasValue, e => e.StudentId == studentId.Value)
                .WhereIf(courseId.HasValue, e => e.CourseId == courseId.Value)
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive.Value);

            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<Enrollment> GetByStudentAndCourseAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();
            return await query.FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId, cancellationToken) ?? throw new InvalidOperationException("Enrollment not found");
        }

        public async Task DeleteAllAsync(Guid? studentId = null, Guid? courseId = null, CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync());
            query = query
                .WhereIf(studentId.HasValue, e => e.StudentId == studentId.Value)
                .WhereIf(courseId.HasValue, e => e.CourseId == courseId.Value);

            var keys = query.Select(x => x.Id);
            await DeleteManyAsync(keys, cancellationToken: cancellationToken);
        }

        public async Task<long> GetCountAsync(Guid? studentId = null, Guid? courseId = null, CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync());
            query = query
                .WhereIf(studentId.HasValue, e => e.StudentId == studentId.Value)
                .WhereIf(courseId.HasValue, e => e.CourseId == courseId.Value);

            return await query.LongCountAsync(cancellationToken);
        }
    }
}
