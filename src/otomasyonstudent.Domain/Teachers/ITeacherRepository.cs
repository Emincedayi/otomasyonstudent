using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
        Task<List<Teacher>> GetListAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task<Teacher> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task DeleteAllAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            CancellationToken cancellationToken = default);
    }
}
