using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace otomasyonstudent.Students
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        Task<List<Student>> GetListAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task<List<StudentWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            string? sort = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default);

        Task<StudentWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default);

        Task DeleteAllAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            EnumGender? gender = null,
            string? email = null,
            Guid? courseId = null,
            CancellationToken cancellationToken = default);
    }
}
