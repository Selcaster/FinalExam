using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.BL.ViewModels.Auths;

public class ProfileUpdateVM
{
    public string? Fullname { get; set; }

    public string? Username { get; set; }

    [Required]
    public IFormFile ProfilePhoto { get; set; }
}
