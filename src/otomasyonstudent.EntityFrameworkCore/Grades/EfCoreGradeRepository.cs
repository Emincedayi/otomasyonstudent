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

namespace otomasyonstudent.Grades
{
    public class EfCoreGradeRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
         : EfCoreRepository<otomasyonstudentDbContext, Grade, Guid>(dbContextProvider), IGradeRepository
    {
        public async Task<List<Grade>> GetListAsync(Guid? enrollmentId = null, Guid? studentId = null, Guid? courseId = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = (await GetQueryableAsync()).AsQueryable();

            // If studentId or courseId filters requested, join Enrollment to filter.
            if (studentId.HasValue || courseId.HasValue)
            {
                var enrollments = dbContext.Set<Enrollments.Enrollment>().AsQueryable();
                query = from g in query
                        join e in enrollments on g.EnrollmentId equals e.Id
                        where (!studentId.HasValue || e.StudentId == studentId.Value)
                              && (!courseId.HasValue || e.CourseId == courseId.Value)
                        select g;
            }
            else
            {
                query = query;
            }

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
