using System.ComponentModel.DataAnnotations;

namespace BugTrackerUI.Models;

public class ReportBugModel
{
     [Required]
     [MaxLength(75)]
     public string Bug { get; set; }

     [Required]
     [MinLength(1)]
     [Display(Name = "Category")]
     public string CategoryId { get; set; }

     [MaxLength(500)]
     public string Description { get; set; }
}

