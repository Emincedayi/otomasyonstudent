using otomasyonstudent.EnumGenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;


namespace otomasyonstudent.Students
{
    public sealed class Student : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string FirstName { get; private set; }

        [NotNull]
        public string LastName { get; private set; }

        [NotNull]
        public EnumGender Gender { get; private set; }

        public string? Email { get; private set; }

        public string? PhoneNumber { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        private Student()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Gender = EnumGender.Unknown;
        }

        public Student(Guid id, string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber, DateTime? dateOfBirth) : base(id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetGender(gender);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
            DateOfBirth = dateOfBirth;
        }

        public void SetFirstName(string firstName)
        {
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), StudentConsts.MaxFirstNameLength, StudentConsts.MinFirstNameLength);
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            Check.NotNull(lastName, nameof(lastName));
            Check.Length(lastName, nameof(lastName), StudentConsts.MaxLastNameLength, StudentConsts.MinLastNameLength);
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
            Check.Length(email, nameof(email), StudentConsts.MaxEmailLength, StudentConsts.MinEmailLength);
            Email = email;
        }

        public void SetPhoneNumber(string? phoneNumber)
        {
            if (phoneNumber is null)
            {
                PhoneNumber = null;
                return;
            }
            Check.Length(phoneNumber, nameof(phoneNumber), StudentConsts.MaxPhoneNumberLength, StudentConsts.MinPhoneNumberLength);
            PhoneNumber = phoneNumber;
        }
    }
}
