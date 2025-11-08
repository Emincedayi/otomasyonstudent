using otomasyonstudent.EnumGenders;
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

namespace otomasyonstudent.Students
{
    public class StudentManager(IStudentRepository studentRepository) : DomainService
    {
        public async Task<Student> CreateAsync(string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber, DateTime? dateOfBirth, CancellationToken cancellationToken = default)
        {
            ValidateInput(firstName, lastName, gender, email, phoneNumber);
            var student = new Student(GuidGenerator.Create(), firstName, lastName, gender, email, phoneNumber, dateOfBirth);
            return await studentRepository.InsertAsync(student, cancellationToken: cancellationToken);
        }

        public async Task<Student> UpdateAsync(Guid id, string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber, DateTime? dateOfBirth, string? concurrencyStamp = null, CancellationToken cancellationToken = default)
        {
            ValidateInput(firstName, lastName, gender, email, phoneNumber);

            var student = await studentRepository.GetAsync(id, cancellationToken: cancellationToken);
            Check.NotNull(student, nameof(student));

            student.SetFirstName(firstName);
            student.SetLastName(lastName);
            student.SetGender(gender);
            student.SetEmail(email);
       
            student.SetConcurrencyStampIfNotNull(concurrencyStamp);

            return await studentRepository.UpdateAsync(student, cancellationToken: cancellationToken);
        }

        private static void ValidateInput(string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber)
        {
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), StudentConsts.MaxFirstNameLength, StudentConsts.MinFirstNameLength);

            Check.NotNull(lastName, nameof(lastName));
            Check.Length(lastName, nameof(lastName), StudentConsts.MaxLastNameLength, StudentConsts.MinLastNameLength);

            Check.Length(email, nameof(email), StudentConsts.MaxEmailLength, StudentConsts.MinEmailLength);
            Check.Length(phoneNumber, nameof(phoneNumber), StudentConsts.MaxPhoneNumberLength, StudentConsts.MinPhoneNumberLength);
        }
    }
}
