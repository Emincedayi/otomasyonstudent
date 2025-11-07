using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace otomasyonstudent.Enrollments
{
    public sealed class Enrollment : FullAuditedAggregateRoot<Guid>
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }

        public bool IsActive { get; private set; }
        public string? Note { get; private set; }

        private Enrollment()
        {
            StudentId = Guid.Empty;
            CourseId = Guid.Empty;
            IsActive = true;
        }

        public Enrollment(Guid id, Guid studentId, Guid courseId, bool isActive = true, string? note = null) : base(id)
        {
            SetStudentId(studentId);
            SetCourseId(courseId);
            IsActive = isActive;
            SetNote(note);
        }

        public void SetStudentId(Guid studentId)
        {
            Check.NotNull(studentId, nameof(studentId));
            StudentId = studentId;
        }

        public void SetCourseId(Guid courseId)
        {
            Check.NotNull(courseId, nameof(courseId));
            CourseId = courseId;
        }

        public void SetActive(bool active) => IsActive = active;

        public void SetNote(string? note)
        {
            if (note is null)
            {
                Note = null;
                return;
            }
            Check.Length(note, nameof(note), EnrollmentConsts.MaxNoteLength, EnrollmentConsts.MinNoteLength);
            Note = note;
        }
    }
}
