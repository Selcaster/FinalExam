using System.ComponentModel.DataAnnotations;

namespace FinalExam.BL.ViewModels.Auths;

public class ForgotEmailVM
{
    [Required, MaxLength(64)]
    public string Email { get; set; }
}
