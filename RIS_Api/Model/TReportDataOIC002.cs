using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC002
    {
        public long? LIST_ID { get; set; }
        public string ISSUE_DATE_FROM { get; set; } = string.Empty;
        public string ISSUE_DATE_TO { get; set; } = string.Empty;
        public string APPLICATION_BRANCH { get; set; } = string.Empty;
        public string PRODUCT_CATEGORY { get; set; } = string.Empty;
        public DateTime? ISSUE_DATE { get; set; }
        public string POLICY_CODE { get; set; } = string.Empty;
        public DateTime? COMMENCEMENT_DATE { get; set; }
        public DateTime? COVERAGE_END_DATE { get; set; }
        public string MAIN_BENEFIT_NAME { get; set; } = string.Empty;
        public long? ENTRY_AGE { get; set; }
        public string INSURED_ID_NO { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public decimal? AMOUNT { get; set; }
        public decimal? PREMIUM { get; set; }
        public decimal? STAMP_DUTY { get; set; }
        public string TR_NO { get; set; } = string.Empty;
        public DateTime? FIRST_COL_DATE { get; set; }
        public decimal? COMMISSION_AMOUNT { get; set; }
        public string AGENT_NAME { get; set; } = string.Empty;
        public string LICENSE_NO { get; set; } = string.Empty;
        public DateTime? INSERT_TIME { get; set; }
        public DateTime? INSERT_TIMESTAMP { get; set; }
        public DateTime? INSURED_DOB { get; set; }
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
