﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract.LoanApplication
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Valuation { get; set; }
        public string ChargeType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long Contact { get; set; }
        public int Postcode { get; set; }
        public bool IsDeleted { get; set; }
        public string UWStatus { get; set; } = String.Empty;
        public string UWReason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CaseReviewedBy { get; set; } 
        public DateTime? CaseReviewedDate { get; set; }
    }
}
