using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RIS_Api.DAL;
using RIS_Api.Interfaces;
using RIS_Api.Model;

namespace RIS_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportDAL _db;

        public ReportController(
            IHttpContextAccessor httpContextAccessor,
            ILogger<ReportController> logger,
            IReportDAL db
        ) : base
        (
            httpContextAccessor,
            logger
        )
        {
            _db = db;
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC001s(DateTime? fromDate, DateTime? toDate, string branch, IOptions<WhereConfig> wherelConfig)
        {
            IEnumerable<TReportDataOIC001> results = await _db.ReportDataOIC001s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch, wherelConfig.Value.userNotIn);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC002s(DateTime? fromDate, DateTime? toDate, string branch, IOptions<WhereConfig> wherelConfig)
        {
            IEnumerable<TReportDataOIC002> results = await _db.ReportDataOIC002s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch, wherelConfig.Value.userNotIn);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC003s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC003> results = await _db.ReportDataOIC003s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC004s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC004> results = await _db.ReportDataOIC004s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC005s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC005> results = await _db.ReportDataOIC005s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC006s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC006> results = await _db.ReportDataOIC006s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC007s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC007> results = await _db.ReportDataOIC007s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC008s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC008> results = await _db.ReportDataOIC008s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC009s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC009> results = await _db.ReportDataOIC009s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC010s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC010> results = await _db.ReportDataOIC010s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC011s(DateTime? fromDate, DateTime? toDate, string branch = "")
        {
            IEnumerable<TReportDataOIC011> results = await _db.ReportDataOIC011s(fromDate ?? new DateTime(), toDate ?? new DateTime(), branch);
            return Ok(results);
        }


        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC001MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC001MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC002MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC002MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC003MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC003MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC004MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC004MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC005MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC005MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC006MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC006MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC007MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC007MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC008MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC008MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC009MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC009MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC010MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC010MaxDate(branch);
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<object> ReportDataOIC011MaxDate(string branch = "")
        {
            IEnumerable<TReportDataOICMaxDate> results = await _db.ReportDataOIC011MaxDate(branch);
            return Ok(results);
        }
        [HttpGet("[action]")]
        public async Task<object> Branch()
        {
            IEnumerable<Branch> results = await _db.Branch();
            return Ok(results);
        }


        [HttpGet("[action]")]
        public async Task<object> BranchByUserName(string userName)
        {
            IEnumerable<User> results = await _db.BranchByUserName(userName);
            return Ok(results);
        }
        [HttpPost("[action]")]
        public async Task<object> TEST()
        {
            IEnumerable<TEST> results = await _db.TEST();
            return Ok(results);
        }
    }
}
