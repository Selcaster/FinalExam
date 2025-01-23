using Microsoft.AspNetCore.Http;

namespace FinalExam.BL.ViewModels.Department
{
    public class DepartmentUpdateVM
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
