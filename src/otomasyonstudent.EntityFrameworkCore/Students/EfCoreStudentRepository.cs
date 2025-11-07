using Microsoft.EntityFrameworkCore;
using otomasyonstudent.EntityFrameworkCore;
using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace otomasyonstudent.Students
{
    public class EfCoreStudentRepository(IDbContextProvider<otomasyonstudentDbContext> dbContextProvider)
         : EfCoreRepository<otomasyonstudentDbContext, Student, Guid>(dbContextProvider), IStudentRepository
    {
        public async Task<List<Student>> GetListAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, firstName, lastName, gender, email, courseId);
            query = query.OrderBy(!string.IsNullOrWhiteSpace(sort) ? sort : StudentConsts.DefaultSorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<List<StudentWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, firstName, lastName, gender, email, courseId);
            query = query.OrderBy(!string.IsNullOrWhiteSpace(sort) ? sort : "Student." + StudentConsts.DefaultSorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<StudentWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return (await GetDbSetAsync()).Where(s => s.Id == id)
                .Select(s => new StudentWithNavigationProperties
                {
                    Student = s
                }).FirstOrDefault()!;
        }

        public async Task DeleteAllAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, firstName, lastName, gender, email, courseId);
            var keys = query.Select(x => x.Student.Id);
            await DeleteManyAsync(keys, cancellationToken: cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationProperties();
            query = ApplyFilter(query, filterText, firstName, lastName, gender, email, courseId);
            return await query.LongCountAsync(cancellationToken);
        }

        // ✅ Student için filtreleme
        protected virtual IQueryable<Student> ApplyFilter(
            IQueryable<Student> query,
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e =>
                    e.FirstName.Contains(filterText!) ||
                    e.LastName.Contains(filterText!) ||
                    (e.Email != null && e.Email.Contains(filterText!)))
                .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName!))
                .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.LastName.Contains(lastName!))
                .WhereIf(gender.HasValue, e => e.Gender.Equals(gender))
                .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email != null && e.Email.Contains(email!));
        }

        // ✅ StudentWithNavigationProperties için overload
        protected virtual IQueryable<StudentWithNavigationProperties> ApplyFilter(
            IQueryable<StudentWithNavigationProperties> query,
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e =>
                    e.Student.FirstName.Contains(filterText!) ||
                    e.Student.LastName.Contains(filterText!) ||
                    (e.Student.Email != null && e.Student.Email.Contains(filterText!)))
                .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.Student.FirstName.Contains(firstName!))
                .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.Student.LastName.Contains(lastName!))
                .WhereIf(gender.HasValue, e => e.Student.Gender.Equals(gender))
                .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Student.Email != null && e.Student.Email.Contains(email!));
        }

        protected virtual async Task<IQueryable<StudentWithNavigationProperties>> GetQueryForNavigationProperties()
        {
            return (await GetDbSetAsync())
                .Select(s => new StudentWithNavigationProperties
                {
                    Student = s
                })
                .AsQueryable();
        }
    }
}
