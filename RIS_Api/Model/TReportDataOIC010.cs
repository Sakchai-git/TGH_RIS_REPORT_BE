using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC010
    {
        public long? LIST_ID { get; set; }
        public string NOTIFICATION_DATE_FROM { get; set; } = string.Empty;
        public string NOTIFICATION_DATE_TO { get; set; } = string.Empty;
        public string APPLICATION_BRANCH { get; set; } = string.Empty;
        public string CASE_NO { get; set; } = string.Empty;
        public string POLICY_CODE { get; set; } = string.Empty;
        public string INSURED_ID_NO { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public string BENEFICIARY_NAME { get; set; } = string.Empty;
        public DateTime? EVENT_DATE { get; set; }
        public decimal? PAYMENT_AMOUNT { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public DateTime? APPROVE_DATE { get; set; }
        public string REMARK { get; set; } = string.Empty;
        public DateTime? CHEQUE_DATE { get; set; }
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
