using RIS_Api.Model;

namespace RIS_Api.Interfaces
{
    public interface IReportDAL
    {
        Task<IEnumerable<TReportDataOIC001>> ReportDataOIC001s(DateTime fromDate, DateTime toDate, string branch,string userNotIn);
        Task<IEnumerable<TReportDataOIC002>> ReportDataOIC002s(DateTime fromDate, DateTime toDate, string branch, string userNotIn);
        Task<IEnumerable<TReportDataOIC003>> ReportDataOIC003s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC004>> ReportDataOIC004s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC005>> ReportDataOIC005s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC006>> ReportDataOIC006s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC007>> ReportDataOIC007s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC008>> ReportDataOIC008s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC009>> ReportDataOIC009s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC010>> ReportDataOIC010s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOIC011>> ReportDataOIC011s(DateTime fromDate, DateTime toDate, string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC001MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC002MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC003MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC004MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC005MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC006MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC007MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC008MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC009MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC010MaxDate(string branch);
        Task<IEnumerable<TReportDataOICMaxDate>> ReportDataOIC011MaxDate(string branch);
        Task<IEnumerable<TEST>> TEST();
        Task<IEnumerable<Branch>> Branch();
        Task<IEnumerable<User>> BranchByUserName(string userName);
    }
}
