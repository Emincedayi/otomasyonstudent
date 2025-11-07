using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace otomasyonstudent.Courses
{
    public sealed class Course : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string Title { get; private set; }

        public string? Code { get; private set; }

        public Guid? TeacherId { get; private set; } // owner/teacher

        public bool IsActive { get; private set; }

        private Course()
        {
            Title = string.Empty;
            Code = null;
            IsActive = true;
        }

        public Course(Guid id, string title, string? code, Guid? teacherId, bool isActive = true) : base(id)
        {
            SetTitle(title);
            SetCode(code);
            SetTeacherId(teacherId);
            IsActive = isActive;
        }

        public void SetTitle(string title)
        {
            Check.NotNull(title, nameof(title));
            Check.Length(title, nameof(title), CourseConsts.MaxTitleLength, CourseConsts.MinTitleLength);
            Title = title;
        }

        public void SetCode(string? code)
        {
            if (code is null)
            {
                Code = null;
                return;
            }
            Check.Length(code, nameof(code), CourseConsts.MaxCodeLength, CourseConsts.MinCodeLength);
            Code = code;
        }

        public void SetTeacherId(Guid? teacherId)
        {
            TeacherId = teacherId;
        }

        public void SetActive(bool active) => IsActive = active;
    }
}
