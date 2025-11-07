using JetBrains.Annotations;
using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace otomasyonstudent.Teachers
{
    public sealed class Teacher : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string FirstName { get; private set; }

        [NotNull]
        public string LastName { get; private set; }

        [NotNull]
        public EnumGender Gender { get; private set; }

        public string? Email { get; private set; }

        public string? PhoneNumber { get; private set; }

        private Teacher()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Gender = EnumGender.Unknown;
        }

        public Teacher(Guid id, string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber) : base(id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetGender(gender);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
        }

        public void SetFirstName(string firstName)
        {
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), TeacherConsts.MaxFirstNameLength, TeacherConsts.MinFirstNameLength);
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            Check.NotNull(lastName, nameof(lastName));
            Check.Length(lastName, nameof(lastName), TeacherConsts.MaxLastNameLength, TeacherConsts.MinLastNameLength);
            LastName = lastName;
        }

        public void SetGender(EnumGender gender) => Gender = gender;

        public void SetEmail(string? email)
        {
            if (email is null)
            {
                Email = null;
                return;
            }
            Check.Length(email, nameof(email), TeacherConsts.MaxEmailLength, TeacherConsts.MinEmailLength);
            Email = email;
        }

        public void SetPhoneNumber(string? phoneNumber)
        {
            if (phoneNumber is null)
            {
                PhoneNumber = null;
                return;
            }
            Check.Length(phoneNumber, nameof(phoneNumber), TeacherConsts.MaxPhoneNumberLength, TeacherConsts.MinPhoneNumberLength);
            PhoneNumber = phoneNumber;
        }
    }
}
