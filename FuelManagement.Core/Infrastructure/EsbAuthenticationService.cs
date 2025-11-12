using Newtonsoft.Json;

namespace FuelManagement.Core.Infrastructure
{
    public class EsbAuthenticationService
    {
        public Profile GetProfile(string username, string token) => null;
        public Profile GetProfileByNationalCode(string nationalCode, string token) => null;
        //public AuthenticatedUserBySessionIDDto ValidateTicket(string ticket) => null;
        public string RequestTokenFromEsb(string EsbUsername, string EsbPassword, string GrantType = "simple") => null;
    }

    public class Profile
    {
        [JsonProperty("userName")] public string? userNameField { get; set; }
        [JsonProperty("firstName")] public string? firstNameField { get; set; }
        [JsonProperty("lastName")] public string? lastNameField { get; set; }
        [JsonProperty("mobileNumber")] public string? mobileNumberField { get; set; }
        [JsonProperty("nationalCode")] public string? nationalCodeField { get; set; }
    }
}
