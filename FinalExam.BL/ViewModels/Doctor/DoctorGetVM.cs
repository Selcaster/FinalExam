using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BL.ViewModels.Doctor
{
    public class DoctorGetVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int DepartmentId { get; set; }
    }
}
