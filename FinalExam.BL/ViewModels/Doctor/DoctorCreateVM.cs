using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BL.ViewModels.Doctor
{
    public class DoctorCreateVM
    {
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int DepartmentId { get; set; }
    }
}
