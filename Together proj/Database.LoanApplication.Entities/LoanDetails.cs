using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.LoanApplication.Entities
{
    [Table("LoanDetails")]
    public class LoanDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Valuation { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string ChargeType { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "Numeric")]
        public long Contact { get; set; }

        [Column(TypeName = "Numeric")]
        public int Postcode { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string UWStatus { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string UWReason { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string CaseReviewedBy { get; set; }

        public DateTime? CaseReviewedDate { get; set; }
    }
}
