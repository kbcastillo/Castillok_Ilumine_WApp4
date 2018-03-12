using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileSalesTool.Models
{
    public class Promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Promotion Type")]
        public int PromotionID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Consumer> Consumers { get; set; }
    }
}