using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC006
    {
        public long? LIST_ID { get; set; }
        public long? REPORT_ID { get; set; }
        public string CRITERIA_DATE_FROM { get; set; } = string.Empty;
        public string CRITERIA_DATE_TO { get; set; } = string.Empty;
        public string CRITERIA_SEG_BRANCH { get; set; } = string.Empty;
        public string CRITERIA_PROD_CATEGORY { get; set; } = string.Empty;
        public string CASE_NO { get; set; } = string.Empty;
        public DateTime? NOTIFICATION_DATE { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string CLAIM_REASON { get; set; } = string.Empty;
        public string POLICY_NO { get; set; } = string.Empty;
        public DateTime? COMMENCEMENT_DATE { get; set; }
        public DateTime? COVERAGE_END_DATE { get; set; }
        public string ID_NO_INSURED { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public decimal? PERIOD_PD { get; set; }
        public decimal? PERIOD_TTD { get; set; }
        public decimal? PERIOD_TPD { get; set; }
        public decimal? SA { get; set; }
        public decimal? CLAIM_AMOUNT_DISABILITY { get; set; }
        public decimal? CLAIM_AMOUNT { get; set; }
        public decimal? CLAIM_AMOUNT_MEDICAL { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public string CHEQUE_NO { get; set; } = string.Empty;
        public DateTime? INSERT_TIME { get; set; }
        public DateTime? INSERT_TIMESTAMP { get; set; }
        public long? USER_ID { get; set; }

        public long? CASE_ID { get; set; }
        public long? BRANCH_ID { get; set; }
        public long? CREATED_BY { get; set; }
        public long? DEPT_ID { get; set; }
        public string BRANCH_RECEIVE_ABBR_NAME { get; set; } = string.Empty;
        public string BRANCH_RECEIVE_NAME { get; set; } = string.Empty;
        public string CREATED_BY_USERNAME { get; set; } = string.Empty;
        public string DEPT_NAME { get; set; } = string.Empty;
        public DateTime? CREATED_DATE { get; set; }
        public string ABBR_NAME { get; set; } = string.Empty;
        public string COMPANY_NAME { get; set; } = string.Empty;


    }
}
