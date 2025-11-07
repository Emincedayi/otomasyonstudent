using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace otomasyonstudent.Grades
{
    public sealed class Grade : FullAuditedAggregateRoot<Guid>
    {
        public Guid EnrollmentId { get; private set; }
        public double Value { get; private set; }
        public string? Note { get; private set; }
        public DateTime Date { get; private set; }

        private Grade()
        {
            EnrollmentId = Guid.Empty;
            Value = 0.0;
            Date = DateTime.UtcNow;
        }

        public Grade(Guid id, Guid enrollmentId, double value, DateTime date, string? note = null) : base(id)
        {
            SetEnrollmentId(enrollmentId);
            SetValue(value);
            Date = date;
            SetNote(note);
        }

        public void SetEnrollmentId(Guid enrollmentId)
        {
            Check.NotNull(enrollmentId, nameof(enrollmentId));
            EnrollmentId = enrollmentId;
        }

        public void SetValue(double value)
        {
            if (value < GradeConsts.MinValue || value > GradeConsts.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Grade must be between {GradeConsts.MinValue} and {GradeConsts.MaxValue}.");
            }
            Value = value;
        }

        public void SetNote(string? note)
        {
            if (note is null)
            {
                Note = null;
                return;
            }
            Check.Length(note, nameof(note), GradeConsts.MaxNoteLength, 0);
            Note = note;
        }
    }
}
