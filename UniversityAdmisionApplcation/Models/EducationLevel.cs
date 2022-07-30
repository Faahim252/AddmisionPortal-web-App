using System.ComponentModel.DataAnnotations;

namespace UniversityAdmisionApplcation.Models
{
    public class EducationLevel
    {
        [Key]
        public int EducationID { get; set; }
        public string EducationLevelName { get; set; }
    }
}
