using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RIS_Api.Interfaces;
using RIS_Api.Model;

namespace RIS_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly IReportDAL _db;

        public LoginController(
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

        [HttpPost("[action]")]
        public async Task<object> Singin([FromBody] Login? data, IOptions<ParameterConfig> urlConfig)
        {
            User user = new User();
            var client = new RestClient();

            var request = new RestRequest(urlConfig.Value.apiAuthenToken, Method.Post);
             request.AddHeader("Authorization", $"Bearer {data?.token}");
            var body = new { AppSecretKey = urlConfig.Value.AppSecretKey, APPID = urlConfig.Value.APPID };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

            RestResponse res = client.Execute(request);

            JObject dataUser = JObject.Parse(res.Content + string.Empty);
            if (dataUser != null)
            {
                JToken? userItem = dataUser.GetValue("userItem");
                if (userItem != null)
                {
                    user.userId = userItem.Value<long>("userId");
                    user.memberId = userItem.Value<long>("memberId");
                    user.username = userItem.Value<string>("username") + string.Empty;
                    JArray Users = userItem.Value<JArray>("Users");
                    if (Users.Count > 0)
                    {
                        JToken userDetail = Users[0];
                        user.Email = userDetail.Value<string>("Email") + string.Empty;
                        user.FirstName = userDetail.Value<string>("FirstName") + string.Empty;
                        user.LastName = userDetail.Value<string>("LastName") + string.Empty;
                        user.NameTH = userDetail.Value<string>("NameTH") + string.Empty;

                    }
                }
            }
            IEnumerable<User> results = await _db.BranchByUserName(user.username);
            if (results.Any())
            {
                User userBranch = results.First();
                user.branchId = userBranch.ORGAN_ID;
                user.abbrName = userBranch.ABBR_NAME;
                user.companyName = userBranch.COMPANY_NAME;
            }


            return Ok(user);
        }
    }
}
