using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDOTNETCOREWEBAPI.Model
{
    public class StudentRepository : IStudentRepository
    {
        private static ConcurrentDictionary<string, StudentMasters> stdMaster = new ConcurrentDictionary<string, StudentMasters>();
        public StudentRepository()
        {
            Add(new StudentMasters
            {
                StdName = "Shina",
                Phone = "+821039120700",
                Email = "shina@gmail.com",
                Address = "Gurgaon,India"
            });
            Add(new StudentMasters
            {
                StdName = "Shanu",
                Phone = "+821039120700",
                Email = "syedshanumcain@gmail.com",
                Address = "Seoul,Korea"
            });
           
        }
        public void Add(StudentMasters studentInfo)
        {
            stdMaster[studentInfo.StdName] = studentInfo;
        }

        public IEnumerable<StudentMasters> getAll()
        {
            List<StudentMasters> _stdInfo = new List<StudentMasters>();
            var studentInfo1 = new StudentMasters
            {
                StdName = "Shanu",
                Phone = "+821039120700",
                Email = "syedshanumcain@gmail.com",
                Address = "Seoul,Korea"
            };
            var studentInfo2 = new StudentMasters
            {
                StdName = "Afraz",
                Phone = "+821000000700",
                Email = "afraz@gmail.com",
                Address = "Madurai,India"
            };
            var studentInfo3 = new StudentMasters
            {
                StdName = "Afreen",
                Phone = "+821012340700",
                Email = "afreen@gmail.com",
                Address = "Chennai,India"
            };
            _stdInfo.Add(studentInfo1);
            _stdInfo.Add(studentInfo2);
            _stdInfo.Add(studentInfo3);
            return _stdInfo;
        }
    }
}
