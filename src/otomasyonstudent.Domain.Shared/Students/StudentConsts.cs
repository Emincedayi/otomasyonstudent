using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyonstudent.Students
{
    public static class StudentConsts
    {

       /* private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "St." : string.Empty);
        }*/

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
