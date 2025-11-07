using Microsoft.EntityFrameworkCore;
using otomasyonstudent.EntityFrameworkCore;
using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace otomasyonstudent.Teachers
{
    public class EfCoreTeacherRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
        : EfCoreRepository<otomasyonstudentDbContext, Teacher, Guid>(dbContextProvider), ITeacherRepository
    {
        public async Task<List<Teacher>> GetListAsync(string? filterText = null, string? firstName = null, string? lastName = null, EnumGender? gender = null, string? email = null, string? sort = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, firstName, lastName, gender, email);
            query = query.OrderBy(!string.IsNullOrWhiteSpace(sort) ? sort : TeacherConsts.DefaultSorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<Teacher> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(id, includeDetails: false, cancellationToken: cancellationToken);
        }

        public async Task DeleteAllAsync(string? filterText = null, string? firstName = null, string? lastName = null, EnumGender? gender = null, string? email = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, firstName, lastName, gender, email);
            var keys = query.Select(x => x.Id);
            await DeleteManyAsync(keys, cancellationToken: cancellationToken);
        }

        public async Task<long> GetCountAsync(string? filterText = null, string? firstName = null, string? lastName = null, EnumGender? gender = null, string? email = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, firstName, lastName, gender, email);
            return await query.LongCountAsync(cancellationToken);
        }

        protected virtual IQueryable<Teacher> ApplyFilter(IQueryable<Teacher> query, string? filterText = null, string? firstName = null, string? lastName = null, EnumGender? gender = null, string? email = null) =>
            query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FirstName.Contains(filterText!) || e.LastName.Contains(filterText!) || (e.Email != null && e.Email.Contains(filterText!)))
                .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName!))
                .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.LastName.Contains(lastName!))
                .WhereIf(gender.HasValue, e => e.Gender.Equals(gender))
                .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email != null && e.Email.Contains(email!));
    }
}
