using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC011
    {
        public long? LIST_ID { get; set; }
        public long? REPORT_ID { get; set; }
        public DateTime? CRITERIA_DATE_FROM { get; set; }
        public DateTime? CRITERIA_DATE_TO { get; set; }
        public string CRITERIA_SEG_BRANCH { get; set; } = string.Empty;
        public string CRITERIA_PROD_CATEGORY { get; set; } = string.Empty;
        public DateTime? APPLICATION_DATE { get; set; }
        public string CANCEL_REASON { get; set; } = string.Empty;
        public string POLICY_NO { get; set; } = string.Empty;
        public DateTime? COMMENCEMENT_DATE { get; set; }
        public DateTime? COVER_END_DATE { get; set; }
        public string MAIN_PLAN_NAME { get; set; } = string.Empty;
        public DateTime? DOB_OF_INSURED { get; set; }
        public string ID_NO_OF_INSURED { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public decimal? SA_MAIN_BENEFIT { get; set; }
        public decimal? SA_ACC_RIDER { get; set; }
        public decimal? SA_HEALTH_RIDER { get; set; }
        public decimal? SA_OTHER_RIDER { get; set; }
        public decimal? SA_TOTAL { get; set; }
        public decimal? PREMIUM_MAIN_BENEFIT { get; set; }
        public decimal? PREMIUM_ACC_RIDER { get; set; }
        public decimal? PREMIUM_HEALTH_RIDER { get; set; }
        public decimal? PREMIUM_OTHER_RIDER { get; set; }
        public decimal? PREMIUM_TOTAL { get; set; }
        public decimal? TOTAL_REFUND_AMOUNT { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public string CHEQUE_NO { get; set; } = string.Empty;
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
