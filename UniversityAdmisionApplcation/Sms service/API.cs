
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace UniversityAdmisionApplcation.Sms_service
{
    public class API
    {
        public String Username { get; set; } = "istaqaana";
        public String Password { get; set; } = "uSY1CyddGHV1/jiRNLFAUQ==";
        

        public async Task<HttpResponseMessage> SendSMS(string mobile, string message)

        {
            HttpClient client = null;
            if (client == null)
            {
                client = new HttpClient
                {
                    BaseAddress = new Uri("https://smsapi.hormuud.com/")
                };
            }

            string username = Username;
            string password = Password;
            HttpResponseMessage response =
            client.PostAsync("Token",
            new StringContent(string.Format("grant_type=password&username={0}&password={1}",
            HttpUtility.UrlEncode(username),
            HttpUtility.UrlEncode(password)), Encoding.UTF8,
            "application/x-www-form-urlencoded")).Result;

            string resultJSON = response.Content.ReadAsStringAsync().Result;

            string AccessToken = (JObject.Parse(resultJSON).SelectToken("access_token")).ToString();


            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

 
           

            // jsonser serializer = new JavaScriptSerializer();

            
           
            HttpResponseMessage Res = await client.PostAsJsonAsync("api/SendSMS", new
                 {
                mobile = mobile,
                message = message,
            });
            if (Res.IsSuccessStatusCode == true)
            {
                var r = Res.Content.ReadAsStringAsync();
            }

            return Res;
        }

        


    }
}

