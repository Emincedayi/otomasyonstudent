using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace otomasyonstudent.Attendances
{
    public sealed class Attendance : FullAuditedAggregateRoot<Guid>
    {
        public Guid EnrollmentId { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsPresent { get; private set; }
        public string? Note { get; private set; }

        private Attendance()
        {
            EnrollmentId = Guid.Empty;
            Date = DateTime.UtcNow;
        }

        public Attendance(Guid id, Guid enrollmentId, DateTime date, bool isPresent, string? note = null) : base(id)
        {
            SetEnrollmentId(enrollmentId);
            Date = date;
            IsPresent = isPresent;
            SetNote(note);
        }

        public void SetEnrollmentId(Guid enrollmentId)
        {
            Check.NotNull(enrollmentId, nameof(enrollmentId));
            EnrollmentId = enrollmentId;
        }

        public void SetPresence(bool presence) => IsPresent = presence;

        public void SetNote(string? note)
        {
            if (note is null)
            {
                Note = null;
                return;
            }
            Check.Length(note, nameof(note), AttendanceConsts.MaxNoteLength, 0);
            Note = note;
        }
    }
}
