using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace woodruff.TokenValidator
{
    public class WSTokenValidator
    {
        public static async Task<bool> VerifiedToken(string token)
        {
            // URI = URI != null ? URI :  "https://tokenvalidationaz.azurewebsites.net/api/validate"  ;
            string URI = "https://tokenvalidationaz.azurewebsites.net/api/validate";

            bool htmlResult = false;

            using (HttpClient hc = new HttpClient())
            {
                try
                {
                    hc.DefaultRequestHeaders.Add("Authorization", token);
                    hc.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


                    var response = await hc.GetAsync(URI);
                    var result = await response.Content.ReadAsStringAsync();


                    htmlResult = Convert.ToBoolean(result);

                }
                catch (Exception ex)
                {
                    return htmlResult;
                }
            }
            return htmlResult;
        }
    }

}
