using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPDOTNETCOREWEBAPI.Model;

namespace ASPDOTNETCOREWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private List<StudentMasters> _stdInfo;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            //InitializeData();
        }

        [HttpGet]
        public IEnumerable<StudentMasters> GetAll()
        {
            StudentMasters _stdInfo1;
            _stdInfo = new List<StudentMasters>();
            var model = _studentRepository.getAll();            
            foreach (var item in model)
            {
                _stdInfo1 = new StudentMasters();
                _stdInfo1.StdName = item.StdName;
                _stdInfo1.Phone = item.Phone;
                _stdInfo1.Email = item.Email;
                _stdInfo1.Address = item.Address;
                _stdInfo.Add(_stdInfo1);
            }
            
            return _stdInfo;
        }
        private void InitializeData()
        {
            _stdInfo = new List<StudentMasters>();
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
        }
    }
}