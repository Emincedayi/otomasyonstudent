using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Teachers
{
    public static class TeacherConsts
    {
        public const int MaxFirstNameLength = 128;
        public const int MinFirstNameLength = 1;
        public const int MaxLastNameLength = 128;
        public const int MinLastNameLength = 1;
        public const int MaxEmailLength = 256;
        public const int MinEmailLength = 5;
        public const int MaxPhoneNumberLength = 32;
        public const int MinPhoneNumberLength = 0;
        public const string DefaultSorting = "LastName,FirstName";
    }
}
