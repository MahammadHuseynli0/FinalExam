using System.ComponentModel.DataAnnotations;

namespace Exam.Areas.Admin.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        [MaxLength(15)]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
