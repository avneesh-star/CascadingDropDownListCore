using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddl_test.Models
{
    public class StudentDto : Sutdent
    {
        public IEnumerable<StudentData> sutdents { get; set; }
    }
}
