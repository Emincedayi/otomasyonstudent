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

namespace otomasyonstudent.Teachers
{
    public class TeacherManager(ITeacherRepository teacherRepository) : DomainService
    {
        public async Task<Teacher> CreateAsync(string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber, CancellationToken cancellationToken = default)
        {
            ValidateInput(firstName, lastName, gender, email, phoneNumber);
            var teacher = new Teacher(GuidGenerator.Create(), firstName, lastName, gender, email, phoneNumber);
            return await teacherRepository.InsertAsync(teacher, cancellationToken: cancellationToken);
        }

        public async Task<Teacher> UpdateAsync(Guid id, string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber, string? concurrencyStamp = null, CancellationToken cancellationToken = default)
        {
            ValidateInput(firstName, lastName, gender, email, phoneNumber);
            var teacher = await teacherRepository.GetByIdAsync(id, cancellationToken: cancellationToken);
            Check.NotNull(teacher, nameof(teacher));

            teacher.SetFirstName(firstName);
            teacher.SetLastName(lastName);
            teacher.SetGender(gender);
            teacher.SetEmail(email);
            teacher.SetPhoneNumber(phoneNumber);
            teacher.SetConcurrencyStampIfNotNull(concurrencyStamp);

            return await teacherRepository.UpdateAsync(teacher, cancellationToken: cancellationToken);
        }

        private static void ValidateInput(string firstName, string lastName, EnumGender gender, string? email, string? phoneNumber)
        {
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), TeacherConsts.MaxFirstNameLength, TeacherConsts.MinFirstNameLength);

            Check.NotNull(lastName, nameof(lastName));
            Check.Length(lastName, nameof(lastName), TeacherConsts.MaxLastNameLength, TeacherConsts.MinLastNameLength);

            Check.Length(email, nameof(email), TeacherConsts.MaxEmailLength, TeacherConsts.MinEmailLength);
            Check.Length(phoneNumber, nameof(phoneNumber), TeacherConsts.MaxPhoneNumberLength, TeacherConsts.MinPhoneNumberLength);
        }
    }
}
