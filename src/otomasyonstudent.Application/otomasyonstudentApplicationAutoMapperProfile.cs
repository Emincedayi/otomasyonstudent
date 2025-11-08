using AutoMapper;

namespace otomasyonstudent;

public class otomasyonstudentApplicationAutoMapperProfile : Profile
{
    public otomasyonstudentApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Students.Student, Students.StudentDto>();
        CreateMap<Students.StudentCreateDto, Students.Student>();
        CreateMap<Students.StudentUpdateDto, Students.Student>();
    }
}
