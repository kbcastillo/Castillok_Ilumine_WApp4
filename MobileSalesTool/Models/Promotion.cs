using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileSalesTool.Models
{
    public class Promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PromotionID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}