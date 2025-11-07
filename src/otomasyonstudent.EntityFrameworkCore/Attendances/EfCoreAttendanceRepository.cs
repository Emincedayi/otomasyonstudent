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

namespace otomasyonstudent.Attendances
{
    public class EfCoreAttendanceRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
         : EfCoreRepository<otomasyonstudentDbContext, Attendance, Guid>(dbContextProvider), IAttendanceRepository
    {
        public async Task<List<Attendance>> GetListAsync(Guid? enrollmentId = null, Guid? studentId = null, Guid? courseId = null, DateTime? from = null, DateTime? to = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = (await GetQueryableAsync()).AsQueryable();

            if (studentId.HasValue || courseId.HasValue)
            {
                var enrollments = dbContext.Set<Enrollments.Enrollment>().AsQueryable();
                query = from a in query
                        join e in enrollments on a.EnrollmentId equals e.Id
                        where (!studentId.HasValue || e.StudentId == studentId.Value)
                              && (!courseId.HasValue || e.CourseId == courseId.Value)
                        select a;
            }

            query = query
                .WhereIf(enrollmentId.HasValue, e => e.EnrollmentId == enrollmentId.Value)
                .WhereIf(from.HasValue, e => e.Date >= from.Value)
                .WhereIf(to.HasValue, e => e.Date <= to.Value);

            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task DeleteAllAsync(Guid? enrollmentId = null, CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync());
            query = query.WhereIf(enrollmentId.HasValue, e => e.EnrollmentId == enrollmentId.Value);
            var keys = query.Select(x => x.Id);
            await DeleteManyAsync(keys, cancellationToken: cancellationToken);
        }

        public async Task<long> GetCountAsync(Guid? enrollmentId = null, CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync());
            query = query.WhereIf(enrollmentId.HasValue, e => e.EnrollmentId == enrollmentId.Value);
            return await query.LongCountAsync(cancellationToken);
        }
    }
}
