using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Core.Entities;

public class Doctors : AuditableEntity
{
    public string Name { get; set; }
    public string Image { get; set; }
    public int DepartmentId { get; set; }
    public Departments Departments { get; set; }

    public static implicit operator Doctors(Departments v)
    {
        throw new NotImplementedException();
    }
}
