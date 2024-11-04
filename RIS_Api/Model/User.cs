using System.Data;
namespace RIS_Api.Model
{
    public class User
    {
        public long? USER_ID { get; set; }
        public long? ORGAN_ID { get; set; }
        public string ABBR_NAME { get; set; } = string.Empty;
        public string COMPANY_NAME { get; set; } = string.Empty;


        public long? userId { get; set; }
        public long? memberId { get; set; }
        public string username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long? branchId { get; set; }
        public string NameTH { get; set; } = string.Empty;
        public string abbrName { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
    }
}
