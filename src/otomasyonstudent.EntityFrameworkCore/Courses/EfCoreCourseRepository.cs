using Microsoft.EntityFrameworkCore;
using otomasyonstudent.EntityFrameworkCore;
using System;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace otomasyonstudent.Courses
{
    public class EfCoreCourseRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
        : EfCoreRepository<otomasyonstudentDbContext, Course, Guid>(dbContextProvider), ICourseRepository
    {
        public async Task<List<Course>> GetListAsync(string? filterText = null, string? title = null, string? code = null, Guid? teacherId = null, bool? isActive = null, string? sort = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, title, code, teacherId, isActive);
            query = query.OrderBy(!string.IsNullOrWhiteSpace(sort) ? sort : CourseConsts.DefaultSorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(id, cancellationToken: cancellationToken);
        }

        public async Task DeleteAllAsync(string? filterText = null, string? title = null, string? code = null, Guid? teacherId = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, title, code, teacherId, null);
            var keys = query.Select(x => x.Id);
            await DeleteManyAsync(keys, cancellationToken: cancellationToken);
        }

        public async Task<long> GetCountAsync(string? filterText = null, string? title = null, string? code = null, Guid? teacherId = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, title, code, teacherId, null);
            return await query.LongCountAsync(cancellationToken);
        }

        protected virtual IQueryable<Course> ApplyFilter(IQueryable<Course> query, string? filterText = null, string? title = null, string? code = null, Guid? teacherId = null, bool? isActive = null) =>
            query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Title.Contains(filterText!) || (e.Code != null && e.Code.Contains(filterText!)))
                .WhereIf(!string.IsNullOrWhiteSpace(title), e => e.Title.Contains(title!))
                .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code != null && e.Code.Contains(code!))
                .WhereIf(teacherId.HasValue, e => e.TeacherId.HasValue && e.TeacherId.Equals(teacherId.Value))
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive.Value);
    }
}
