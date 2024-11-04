using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
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

        public async Task<IEnumerable<TReportDataOIC001>> ReportDataOIC001s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC001>(sql: "SELECT T_REPORT_DATA_OIC001.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE     ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n FROM T_REPORT_DATA_OIC001  WITH (NOLOCK)\r\n LEFT JOIN  t_contract_master a ON a.POLICY_CODE = T_REPORT_DATA_OIC001.POLICY_CODE \r\nleft outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id \r\nleft outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id \r\nWHERE T_REPORT_DATA_OIC001.ISSUE_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }
          
        }

        public async Task<IEnumerable<TReportDataOIC002>> ReportDataOIC002s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC002>(sql: "SELECT main.*\r\n,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO\r\n    , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME\r\n    , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERT_TIMESTAMP AS CREATED_DATE ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC002 main  WITH (NOLOCK)\r\nLEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE\r\nleft outer join t_company_organ b\r\n    on a.application_branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.ISSUE_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOIC003>> ReportDataOIC003s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC003>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC003 main  WITH (NOLOCK)\r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.NOTIFICATION_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<TReportDataOIC004>> ReportDataOIC004s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC004>(sql: "SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE  ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME    FROM T_REPORT_DATA_OIC004 main  WITH (NOLOCK) LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.MATURITY_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC005>> ReportDataOIC005s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC005>(sql: "SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE   ,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME   FROM T_REPORT_DATA_OIC005 main  WITH (NOLOCK) LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.SB_DUE_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);
            }//SB_DUE_DATE
        }

        public async Task<IEnumerable<TReportDataOIC006>> ReportDataOIC006s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC006>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC006 main  WITH (NOLOCK)\r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.NOTIFICATION_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC007>> ReportDataOIC007s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC007>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC007 main  WITH (NOLOCK)\r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.NOTIFICATION_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//NOTIFICATION_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC008>> ReportDataOIC008s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC008>(sql: "SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME      FROM T_REPORT_DATA_OIC008 main  WITH (NOLOCK) LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.MATURITY_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//MATURITY_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC009>> ReportDataOIC009s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC009>(sql: "SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME      FROM T_REPORT_DATA_OIC009 main  WITH (NOLOCK) LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_CODE left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.SURRENDER_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//SURRENDER_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC010>> ReportDataOIC010s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC010>(sql: "SELECT main.*\r\n,A.CASE_ID\r\n    , A.BRANCH_ID, B.ABBR_NAME AS BRANCH_RECEIVE_ABBR_NAME, B.COMPANY_NAME AS BRANCH_RECEIVE_NAME\r\n    , A.INSERTED_BY AS CREATED_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME\r\n    , A.INSERTED_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME\r\n    FROM T_REPORT_DATA_OIC010 main  WITH (NOLOCK)\r\nLEFT JOIN  t_claim_case a ON a.CASE_NO =main.CASE_NO\r\nleft outer join t_company_organ b\r\n    on a.branch_id = b.organ_id\r\nleft outer join t_user c\r\n    on a.inserted_by = c.user_id\r\nleft outer join t_dept d\r\n    on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.PAYMENT_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//PAYMENT_DATE
            }
        }

        public async Task<IEnumerable<TReportDataOIC011>> ReportDataOIC011s(DateTime fromDate, DateTime toDate, string branch)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("fromDate", fromDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("toDate", toDate.ToString("yyy-MM-dd", new CultureInfo("en-US")), DbType.String);
                dynamicParameters.Add("branch", branch, DbType.String);

                return await db.QueryAsync<TReportDataOIC011>(sql: "SELECT main.* ,A.POLICY_ID, A.POLICY_CODE AS POLICY_NO     , A.APPLICATION_BRANCH_ID, B.ABBR_NAME AS APPLICATION_BRANCH_ABBR_NAME, B.COMPANY_NAME AS APPLICATION_BRANCH_NAME     , A.INSERTED_BY AS INSERT_BY, C.USER_NAME AS CREATED_BY_USERNAME, C.DEPT_ID, D.DEPT_NAME     , A.INSERT_TIMESTAMP AS CREATED_DATE,t_company_organ.ABBR_NAME,t_company_organ.COMPANY_NAME      FROM T_REPORT_DATA_OIC011 main  WITH (NOLOCK) LEFT JOIN  t_contract_master a ON a.POLICY_CODE = main.POLICY_NO left outer join t_company_organ b     on a.application_branch_id = b.organ_id left outer join t_user c     on a.inserted_by = c.user_id left outer join t_dept d     on c.dept_id = d.dept_id\r\nLEFT JOIN T_USER ON T_USER.USER_ID = A.INSERTED_BY\r\nleft outer join t_company_organ     on T_USER.organ_id = t_company_organ.organ_id WHERE main.APPLICATION_DATE BETWEEN @fromDate AND @toDate AND (B.ABBR_NAME = @branch OR @branch = '0')", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }
        public async Task<IEnumerable<Branch>> Branch()
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();

                return await db.QueryAsync<Branch>(sql: "SELECT ORGAN_ID,ABBR_NAME,COMPANY_NAME FROM T_COMPANY_ORGAN WHERE ABBR_NAME NOT LIKE '9%' ORDER BY ORGAN_ID", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }

        public async Task<IEnumerable<User>> BranchByUserName(string UserName)
        {
            using (var db = new SqlConnection(dbConnectionStringeBaoLSStaging))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("UserName", UserName, DbType.String);

                return await db.QueryAsync<User>(sql: "SELECT T_USER.USER_ID,T_USER.ORGAN_ID,T_COMPANY_ORGAN.COMPANY_NAME,T_COMPANY_ORGAN.ABBR_NAME FROM T_USER \r\nLEFT JOIN T_COMPANY_ORGAN ON T_USER.ORGAN_ID = T_COMPANY_ORGAN.ORGAN_ID  \r\nWHERE LOWER(T_USER.USER_NAME) = LOWER(@UserName)", param: dynamicParameters, commandType: CommandType.Text);
            }
        }
        public async Task<IEnumerable<TEST>> TEST()
        {
            using (var db = new SqlConnection(dbConnectionString))
            {
                db.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();

                return await db.QueryAsync<TEST>(sql: "SELECT * FROM TEST", param: dynamicParameters, commandType: CommandType.Text);//ไม่แน่ใจ//APPLICATION_DATE
            }
        }
    }
}
