using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileSalesTool.Models
{
    public class AccountType
    {
        [Key]
        [ForeignKey("Consumer")]
        public int ConsumerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Account Type: CRU/BSU")]
        public string Location { get; set; }

        public virtual Consumer Consumer { get; set; }
    }
}