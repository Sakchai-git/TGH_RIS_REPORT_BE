using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC003
    {
        public long? LIST_ID { get; set; }
        public string NOTIFICATION_DATE_FROM { get; set; } = string.Empty;
        public string NOTIFICATION_DATE_TO { get; set; } = string.Empty;
        public string APPLICATION_BRANCH { get; set; } = string.Empty;
        public string CASE_NO { get; set; } = string.Empty;
        public DateTime? NOTIFICATION_DATE { get; set; }
        public DateTime? DEATH_DATE { get; set; }
        public string DEATH_REASON { get; set; } = string.Empty;
        public string POLICY_CODE { get; set; } = string.Empty;
        public DateTime? VALIDATE_DATE { get; set; }
        public DateTime? EXPIRE_DATE { get; set; }
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public DateTime? INSURED_BIRTHDAY { get; set; }
        public string INSURED_ID_NO { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public string BENEFICIARY_NAME { get; set; } = string.Empty;
        public decimal? MAIN_SA { get; set; }
        public decimal? ACC_RIDER_SA { get; set; }
        public decimal? HEALTH_RIDER_SA { get; set; }
        public decimal? OTHER_RIDER_SA { get; set; }
        public decimal? MAIN_PAY_AMT { get; set; }
        public decimal? ACC_RIDER_PAY_AMT { get; set; }
        public decimal? HEALTH_RIDER_PAY_AMT { get; set; }
        public decimal? OTHER_RIDER_PAY_AMT { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public string CHEQUE_NO { get; set; } = string.Empty;
        public DateTime? INSERT_TIME { get; set; }
        public DateTime? INSERT_TIMESTAMP { get; set; }
        public decimal? TOTAL_PAYMENT { get; set; }
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
