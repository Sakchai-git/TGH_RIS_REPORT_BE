using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using RIS_Api.Interfaces;
using RIS_Api.Model;
using System.Data;
using System.Globalization;

namespace RIS_Api.DAL
{
    public class ReportDAL : BaseDAL, IReportDAL
    {
        public ReportDAL(IHttpContextAccessor httpContextAccessor, IOptions<ConnectionStringSettings> ConnectionStringSettings) : base(httpContextAccessor, ConnectionStringSettings)
        {
            // Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task<IEnumerable<TReportDataOIC001>> ReportDataOIC001s(DateTime fromDate, DateTime toDate, string branch, string userNotIn)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC001>(sql: $"SELECT * FROM (\r\nSELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE     ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME  , f.abbr_name as SERVICE_BRANCH_CODE, f.company_name as SERVICE_BRANCH_NAME \r\n,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\nFROM T_REPORT_DATA_OIC001 main     LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE  left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id  left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id \r\nleft outer join ebao_ls_prod.t_company_organ f\r\n    on a.organ_id = f.organ_id \r\nWHERE TO_CHAR(main.ISSUE_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (F.ABBR_NAME = :branch OR :branch = '0')\r\nAND UPPER(C.USER_NAME) NOT IN {userNotIn}\r\n) main\r\nWHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);
            }
          
        }

        public async Task<IEnumerable<TReportDataOIC002>> ReportDataOIC002s(DateTime fromDate, DateTime toDate, string branch, string userNotIn)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC002>(sql: $"SELECT * FROM (\r\nSELECT MAIN.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, \r\nB.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME  \r\n, A.INSERT_TIMESTAMP AS CREATED_DATE ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME     \r\n,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\nFROM T_REPORT_DATA_OIC002 \r\nmain    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b    \r\non a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d \r\non c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ\r\non T_USER.organ_id = t_company_organ.organ_id \r\nWHERE TO_CHAR(main.ISSUE_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\nAND UPPER(C.USER_NAME) NOT IN {userNotIn}\r\n) main\r\nWHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOIC003>> ReportDataOIC003s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC003>(sql: "SELECT * FROM (\r\nSELECT main.* ,A.CASE_ID     , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME     , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME     \r\n,ROW_NUMBER() OVER (PARTITION BY MAIN.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\nFROM T_REPORT_DATA_OIC003 main    LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO left outer join t_company_organ b     on a.branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id \r\nWHERE TO_CHAR(main.NOTIFICATION_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\n) main\r\nWHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOIC004>> ReportDataOIC004s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC004>(sql: "SELECT * FROM (\r\nSELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE  ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME    \r\n,ROW_NUMBER() OVER (PARTITION BY main.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\nFROM T_REPORT_DATA_OIC004 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id\r\nWHERE TO_CHAR(main.MATURITY_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\n) main\r\nWHERE MAIN.ROWNUMS = 1\r\norder by main.MATURITY_DATE ASC", param: dynamicParameters, commandType: CommandType.Text);//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC005>> ReportDataOIC005s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC005>(sql: "SELECT * FROM (\r\nSELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE   ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME   \r\n,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\nFROM T_REPORT_DATA_OIC005 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id\r\nWHERE TO_CHAR(main.SB_DUE_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\n) main\r\nWHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);
            }//SB_DUE_DATE
        }

        public async Task<IEnumerable<TReportDataOIC006>> ReportDataOIC006s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC006>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC006 main   \r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE TO_CHAR(main.NOTIFICATION_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC007>> ReportDataOIC007s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC007>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC007 main   \r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE TO_CHAR(main.NOTIFICATION_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC008>> ReportDataOIC008s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC008>(sql: "SELECT * FROM (\r\nSELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME     \r\n,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\n FROM T_REPORT_DATA_OIC008 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id\r\nWHERE TO_CHAR(main.MATURITY_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\n) main\r\nWHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC009>> ReportDataOIC009s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);
                //PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC
                return await db.QueryAsync<TReportDataOIC009>(sql: $@"SELECT * FROM (
SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, T_USER.USER_NAME AS CREATED_BY_USERNAME, T_USER.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME      
,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE ORDER BY MAIN.INSERT_TIME DESC) rownums
from t_policy_change pch
INNER join t_cs_application csa
    on pch.master_chg_id = csa.change_id
inner join t_contract_master A
    on csa.policy_id = A.policy_id
left outer join t_company_organ b
    on csa.org_id = b.organ_id
 LEFT JOIN T_REPORT_DATA_OIC009 main ON main.policy_code = A.policy_code
LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id
left outer join t_dept d     on T_USER.dept_id = d.dept_id 
WHERE TO_CHAR(main.SURRENDER_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')

) main
WHERE MAIN.ROWNUMS = 1", param: dynamicParameters, commandType: CommandType.Text);//SURRENDER_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC010>> ReportDataOIC010s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC010>(sql: "SELECT * FROM ( SELECT main.* ,A.NOTIFICATION_DATE,A.CASE_ID     , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME     , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME     ,ROW_NUMBER() OVER (PARTITION BY main.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums  \r\nFROM T_REPORT_DATA_OIC010 main   \r\n LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO \r\nleft outer join t_company_organ b     on a.branch_id = b.organ_id \r\nleft outer join t_user c     on a.inserted_by = c.user_id \r\nleft outer join t_dept d     on c.dept_id = d.dept_id \r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\n left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id  \r\nWHERE TO_CHAR(A.NOTIFICATION_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0') ) main WHERE MAIN.ROWNUMS = 1 order BY MAIN.NOTIFICATION_DATE ASC", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//EVENT_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC011>> ReportDataOIC011s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC011>(sql: "SELECT * FROM (\r\nSELECT main.* ,A.POLICY_ID     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME    \r\n,ROW_NUMBER() OVER (PARTITION BY A.POLICY_CODE,B.ABBR_NAME ORDER BY MAIN.INSERT_TIME DESC) rownums\r\n  FROM T_REPORT_DATA_OIC011 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_NO left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id LEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY left outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id\r\nWHERE TO_CHAR(main.APPLICATION_DATE,'YYYY-MM-DD') BETWEEN :fromDate AND :toDate AND (B.ABBR_NAME = :branch OR :branch = '0')\r\n) main\r\nWHERE MAIN.ROWNUMS = 1\r\n", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC001MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(MAIN.ISSUE_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC001 main     \r\nLEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE  \r\nleft outer join ebao_ls_prod.t_company_organ f\r\n    on a.organ_id = f.organ_id \r\nWHERE  (F.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }

        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC002MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.ISSUE_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC002 \r\nmain    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b    \r\non a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')\r\n", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC003MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.NOTIFICATION_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC003 main    LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO left outer join t_company_organ b     on a.branch_id = b.organ_id \r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC004MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.MATURITY_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC004 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')\r\n", param: dynamicParameters, commandType: CommandType.Text);//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC005MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.SB_DUE_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC005 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }//SB_DUE_DATE
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC006MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.NOTIFICATION_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC006 main   LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO left outer join t_company_organ b    on a.branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC007MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.NOTIFICATION_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC007 main    LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO left outer join t_company_organ b     on a.branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')\r\n", param: dynamicParameters, commandType: CommandType.Text);//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC008MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.MATURITY_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC008 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC009MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.SURRENDER_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC009 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')\r\n", param: dynamicParameters, commandType: CommandType.Text);//SURRENDER_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC010MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(a.NOTIFICATION_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC010 main     LEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO  left outer join t_company_organ b     on a.branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//EVENT_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC011MaxDate(string branch)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOICMaxDate>(sql: "SELECT MAX(main.APPLICATION_DATE) MAX_DATE\r\nFROM T_REPORT_DATA_OIC011 main    LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_NO left outer join t_company_organ b     on a.application_branch_id = b.organ_id\r\nWHERE  (B.ABBR_NAME = :branch OR :branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }
        public async Task<IEnumerable<Branch>> Branch()
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                //SELECT BRANCH_CODE ABBR_NAME\t,BRANCH_NAME COMPANY_NAME FROM T_BUSINESS_UNIT_BRANCH  where BUSINESS_UNIT = 3
                return await db.QueryAsync<Branch>(sql: "SELECT ORGAN_ID ,COMPANY_NAME\t,ABBR_NAME  FROM T_COMPANY_ORGAN  WHERE  ABBR_NAME NOT LIKE '9%' ", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }

        public async Task<IEnumerable<User>> BranchByUserName(string UserName)
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("UserName", UserName, DbType.String);

                return await db.QueryAsync<User>(sql: "SELECT T_USER.USER_ID,T_USER.ORGAN_ID,T_COMPANY_ORGAN.COMPANY_NAME,T_COMPANY_ORGAN.ABBR_NAME FROM T_USER \r\nLEFT JOIN T_COMPANY_ORGAN ON T_USER.ORGAN_ID = T_COMPANY_ORGAN.ORGAN_ID  \r\nWHERE LOWER(T_USER.USER_NAME) = LOWER(:UserName)", param: dynamicParameters, commandType: CommandType.Text);
            }
        }
        public async Task<IEnumerable<TEST>> TEST()
        {
            using (var db = new OracleConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();

                return await db.QueryAsync<TEST>(sql: "SELECT * FROM T_USER", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }
    }
}
