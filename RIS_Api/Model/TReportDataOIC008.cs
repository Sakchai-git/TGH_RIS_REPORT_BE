﻿using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC008
    {
        public long? LIST_ID { get; set; }
        public DateTime? CRITERIA_DATE_FROM { get; set; }
        public DateTime? CRITERIA_DATE_TO { get; set; }
        public string CRITERIA_BRANCH { get; set; } = string.Empty;
        public DateTime? MATURITY_DATE { get; set; }
        public string POLICY_CODE { get; set; } = string.Empty;
        public DateTime? COMMENCEMENT_DATE { get; set; }
        public DateTime? COVERAGE_END_DATE { get; set; }
        public string MAIN_BENEFIT_NAME { get; set; } = string.Empty;
        public string INSURED_ID_NO { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public DateTime? INSURED_DOB { get; set; }
        public decimal? MAIN_BENEFIT_SA { get; set; }
        public long? ANNUITY_INSTALLMENT { get; set; }
        public decimal? PAYMENT_AMOUNT { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public DateTime? INSERT_TIME { get; set; }
        public DateTime? INSERT_TIMESTAMP { get; set; }
        public long? USER_ID { get; set; }

        public long? POLICY_ID { get; set; }
        public long? APPLICATION_BRANCH_ID { get; set; }
        public long? INSERT_BY { get; set; }
        public long? DEPT_ID { get; set; }
        public string APPLICATION_BRANCH_ABBR_NAME { get; set; } = string.Empty;
        public string APPLICATION_BRANCH_NAME { get; set; } = string.Empty;
        public string CREATED_BY_USERNAME { get; set; } = string.Empty;
        public string DEPT_NAME { get; set; } = string.Empty;
        public DateTime? CREATED_DATE { get; set; }
        public string ABBR_NAME { get; set; } = string.Empty;
        public string COMPANY_NAME { get; set; } = string.Empty;

    }
}