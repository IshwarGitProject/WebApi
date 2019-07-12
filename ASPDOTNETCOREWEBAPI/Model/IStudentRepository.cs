using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDOTNETCOREWEBAPI.Model
{
    public interface IStudentRepository
    {
        IEnumerable<StudentMasters> getAll();
        void Add(StudentMasters info);
    }
}
