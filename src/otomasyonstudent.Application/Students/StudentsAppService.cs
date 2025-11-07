using AutoMapper.Internal.Mappers;
using otomasyonstudent.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;



namespace otomasyonstudent.Students
{

    public class StudentsAppService :
        CrudAppService<
            Student,                // Entity
            StudentDto,             // DTO to return
            Guid,                   // Primary Key
            PagedAndSortedResultRequestDto, // Paging input
            StudentCreateDto,        // Create input
            StudentUpdateDto>,       // Update input
        IStudentsAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentManager _studentManager;

        public StudentsAppService(
            IStudentRepository studentRepository,
            StudentManager studentManager)
            : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
        }

      /*  public override async Task<StudentDto> CreateAsync(StudentCreateDto input)
        {
            var student = await _studentManager.CreateAsync(
                input.StudentNo, input.FirstName, input.LastName, input.Email, input.BirthDate
            );

            await _studentRepository.InsertAsync(student);
            return ObjectMapper.Map<Student, StudentDto>(student);
        }*/

        public override async Task<StudentDto> UpdateAsync(Guid id, StudentUpdateDto input)
        {
            var student = await _studentRepository.GetAsync(id);
            //await _studentManager.UpdateAsync(student, input.FirstName, input.LastName, input.Email, input.BirthDate);
            await _studentRepository.UpdateAsync(student);
            return ObjectMapper.Map<Student, StudentDto>(student);
        }
    }
}
