using System.Data;
namespace RIS_Api.Model
{
    public class TReportDataOIC004
    {
        public long? LIST_ID { get; set; }
        public string MATURITY_DATE_FROM { get; set; } = string.Empty;
        public string MATURITY_DATE_TO { get; set; } = string.Empty;
        public string APPLICATION_BRANCH { get; set; } = string.Empty;
        public DateTime? MATURITY_DATE { get; set; }
        public string POLICY_CODE { get; set; } = string.Empty;
        public DateTime? VALIDATE_DATE { get; set; }
        public DateTime? EXPIRE_DATE { get; set; }
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public DateTime? INSURED_BIRTHDAY { get; set; }
        public string INSURED_ID_NO { get; set; } = string.Empty;
        public string INSURED_NAME { get; set; } = string.Empty;
        public decimal? MAIN_SA { get; set; }
        public decimal? MATURITY_AMOUNT { get; set; }
        public decimal? DEBIT_AMOUNT { get; set; }
        public decimal? NET_PAYMENT { get; set; }
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
