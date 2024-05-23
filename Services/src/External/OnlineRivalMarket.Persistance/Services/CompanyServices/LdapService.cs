using Newtonsoft.Json;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.Dtos;
using System.Net.Http.Json;

namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public class LdapService(HttpClient _httpClient) : ILdapService
    {
        public async Task<LdapUserDtos> GetAllUser()
        {
            var apiUrl = $@"https://tickettest.asinteknoloji.com/api/GetAllUser";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LdapUserDtos>(responseData);
                return result;
            }
            else
            {
                throw new Exception($"API isteği başarısız. Durum Kodu: {response.StatusCode}");
            }
        }
        public async Task<Result<LdapUserDto>> Login(string userNameAndEmail, string password)
        {
            var apiUrl = $@"https://tickettest.asinteknoloji.com/api/login";
            var postData = new
            {
                UserNameAndEmail = userNameAndEmail,
                password = password
            };
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<LdapUserDto>();
                        return Result<LdapUserDto>.Succeed(result);
                    }
                    else
                    {
                        return Result<LdapUserDto>.Failure(500, "Giriş Başarısız!");
                    }
                }
                catch (Exception ex)
                {
                    Result<string>.Failure(ex.Message);
                }
            }
            return Result<LdapUserDto>.Failure(500, "Giriş Başarısız!");
        }
    }
}
