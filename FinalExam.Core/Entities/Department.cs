using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Core.Entities;

public class Departments : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ICollection<Doctors> Doctors { get; set; }

    public static implicit operator Departments(Doctors v)
    {
        throw new NotImplementedException();
    }
}
