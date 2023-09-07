using System.ComponentModel.DataAnnotations;

namespace Hr.LeaveManagement.BlazorUI.Models.LeaveTypes
{
    public class LeaveTypeVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Number")]
        public int DefaultDays { get; set; }
    }
}
