using SmartSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class StudentManageAccountViewModel
    {
        public ChangePasswordViewModel ChangePassword { get; set; }
        public Student Student { get; set; }
        public Student Student1 { get; set; }
        public int ParentId { get; set; }
        public int DepartmentId { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Student> Students { get; set; }
        public List<Department> Departments { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}