using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.BL.ViewModels.Department;

public class DepartmentCreateVM
{
    [MaxLength(32), Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile ImageUrl { get; set; }
}