using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Infrastructure;

public class EsbAuthenticationService
{
    // گرفتن اطلاعات 
    public Profile GetProfile(string username, string token)
    {
        //// اطلاعات رو با نام کاربری میگیرم 
        //var getProfileByUsername = new GetProfileByUsernameForm
        //{
        //    TokenID = token,
        //    username = username
        //};

        //string output = JsonConvert.SerializeObject(getProfileByUsername, Formatting.Indented);
        //var result = DataUtility.PostHttp(new Uri(_CasUrlSetting.GetProfileByUsername), output);
        //Profile authenticated = JsonConvert.DeserializeObject<Profile>(result);

        //return authenticated;
        return null;
    }

    public Profile GetProfileByNationalCode(string nationalCode, string token)
    {
        //var getProfileByNationalCode = new
        //{
        //    TokenID = token,
        //    nationalCode = nationalCode
        //};

        //var output = JsonConvert.SerializeObject(getProfileByNationalCode, Formatting.Indented);
        //var result = DataUtility.PostHttp(new Uri(_CasUrlSetting.GetProfileByNationalCode), output);
        //Console.WriteLine(result);
        //var authenticated = JsonConvert.DeserializeObject<Profile>(result);

        //return authenticated;
        return null;
    }


    //بررسی تیکت  اصلی
    public AuthenticatedUserBySessionIDDto ValidateTicket(string ticket)
    {
        //var validateTicket = new validateTicket
        //{
        //    Ticket = ticket,
        //    Service = "http://uac.qom.ir:4223"
        //};

        //var result = DataUtility.GetHttp(new Uri(_CasUrlSetting.ValidateTicket), validateTicket);
        //AuthenticatedUserBySessionIDDto authenticated =
        //    JsonConvert.DeserializeObject<AuthenticatedUserBySessionIDDto>(result);

        //return authenticated;
        return null;
    }

    public string RequestTokenFromEsb(string EsbUsername, string EsbPassword, string GrantType = "simple")
    {
        //var passMD5 = DataUtility.CreateMD5(EsbPassword);
        //var challenge = DataUtility.GetHttpHeader(new Uri(_CasUrlSetting.AuthenticationRequest));
        //var challenge_passMD5 = DataUtility.CreateMD5(challenge[0] + passMD5);
        //var validateToken = new ValidateTokenForm
        //{
        //    Username = EsbUsername,
        //    ChallResPass = challenge_passMD5,
        //    TokenID = challenge[1]
        //};

        //string output = JsonConvert.SerializeObject(validateToken, Formatting.Indented);
        //DataUtility.PostHttp(new Uri(_CasUrlSetting.Authenticate), output);
        //return validateToken.TokenID;
        return null;
    }
}

public class GetProfileByUsernameForm
{
    public string TokenID { get; set; }
    public string username { get; set; }
}

public class validateTicket
{
    public string Ticket { get; set; }
    public string Service { get; set; }
}

public class ValidateTokenForm
{
    public string Username { get; set; }
    public string ChallResPass { get; set; }
    public string TokenID { get; set; }
}

public class AuthenticatedUserBySessionIDDto
{
    public AuthenticatedUserBySessionIDDto()
    {
        serviceResponse = new ServiceResponse();
    }

    public ServiceResponse serviceResponse { get; set; }
    public string usernameField { get; set; }
    public bool statusField { get; set; }
}

public class ServiceResponse
{
    public ServiceResponse()
    {
        authenticationSuccess = new AuthenticationSuccess();
        authenticationFailure = new AuthenticationFailure();
    }

    public AuthenticationSuccess authenticationSuccess { get; set; }
    public AuthenticationFailure authenticationFailure { get; set; }
}

public class Attributes
{
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string title { get; set; }
}

public class AuthenticationSuccess
{
    public AuthenticationSuccess()
    {
        attributes = new Attributes();
    }

    public string user { get; set; }
    public Attributes attributes { get; set; }
}

public class AuthenticationFailure
{
    public string code { get; set; }
    public string description { get; set; }
}

public class AvatarField
{
    public string tinyField { get; set; }
    public string smallField { get; set; }
    public string mediumField { get; set; }
    public string largeField { get; set; }
    public string masterField { get; set; }
}

public class Profile
{
    [JsonProperty("userName")]
    public string? userNameField { get; set; }
    [JsonProperty("firstName")]
    public string? firstNameField { get; set; }
    [JsonProperty("lastName")]
    public string? lastNameField { get; set; }
    [JsonProperty("mobileNumber")]
    public string? mobileNumberField { get; set; }
    [JsonProperty("email")]
    public string? emailField { get; set; }
    [JsonProperty("isEmployee")]
    public bool isEmployeeField { get; set; }
    [JsonProperty("nationalCode")]
    public string? nationalCodeField { get; set; }
    [JsonProperty("birthDate")]
    public object birthDateField { get; set; }
    [JsonProperty("avatar")]
    public AvatarField avatarField { get; set; }
    [JsonProperty("postal")]
    public object postalField { get; set; }
    public object? PersonalCode { get; set; }
    [JsonProperty("address")]
    public object? addressField { get; set; }
    public object? FatherName { get; set; }
    public object? ProvinceName { get; set; }

    public decimal? sumSalary { get; set; }
    public string? postName { get; set; }

    [Display(Name = "وضعیت اشتغال1")]
    public string? JobState_1 { get; set; }

    [Display(Name = "شماره حساب")]
    public object? CreditNumber { get; set; }

    [Display(Name = "جنسیت")]
    public object? Sex { get; set; }

    [Display(Name = "تاریخ شروع همکاری")]
    public string? EmployeeDate { get; set; }

    [JsonProperty("وضعیت شغلی")]
    public string? ContractName { get; set; }
    public string? contractBy { get; set; }
    public string? contractByTitle { get; set; }
}

