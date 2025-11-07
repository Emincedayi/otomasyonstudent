using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace otomasyonstudent.Courses
{
    public class CourseManager(ICourseRepository courseRepository) : DomainService
    {
        public async Task<Course> CreateAsync(string title, string? code, Guid? teacherId, CancellationToken cancellationToken = default)
        {
            ValidateInput(title, code);
            var course = new Course(GuidGenerator.Create(), title, code, teacherId);
            return await courseRepository.InsertAsync(course, cancellationToken: cancellationToken);
        }

        public async Task<Course> UpdateAsync(Guid id, string title, string? code, Guid? teacherId, bool isActive, string? concurrencyStamp = null, CancellationToken cancellationToken = default)
        {
            ValidateInput(title, code);
            var course = await courseRepository.GetByIdAsync(id, cancellationToken: cancellationToken);
            Check.NotNull(course, nameof(course));

            course.SetTitle(title);
            course.SetCode(code);
            course.SetTeacherId(teacherId);
            course.SetActive(isActive);
            course.SetConcurrencyStampIfNotNull(concurrencyStamp);

            return await courseRepository.UpdateAsync(course, cancellationToken: cancellationToken);
        }

        private static void ValidateInput(string title, string? code)
        {
            Check.NotNull(title, nameof(title));
            Check.Length(title, nameof(title), CourseConsts.MaxTitleLength, CourseConsts.MinTitleLength);
            if (code is not null)
                Check.Length(code, nameof(code), CourseConsts.MaxCodeLength, CourseConsts.MinCodeLength);
        }
    }
}
