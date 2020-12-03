using IdentityModel.Client;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Areas.PCBuilds.Extensions
{
    internal static class ApiRequests
    {
        /// <summary>
        /// Requests API service to return list of objects.
        /// </summary>
        /// <param name="accessToken">Authorization access token.</param>
        /// <param name="uri">API service address.</param>
        /// <returns>List of objects.</returns>
        internal static async Task<string> GetAsync(string accessToken, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                using (HttpResponseMessage response = await httpClient.GetAsync(uri))
                {
                    return await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<List<Object>>(apiResponse);
                }
            }
        }

        /// <summary>
        /// Requests API service to create an object.
        /// </summary>
        /// <param name="accessToken">Authorization access token.</param>
        /// <param name="uri">API service address.</param>
        /// <param name="model">Object.</param>
        /// <returns>API service response.</returns>
        internal static async Task<string> PostAsync(string accessToken, string uri, object model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await httpClient.PostAsync(uri, content))
                {
                    return await response.Content.ReadAsStringAsync();
                    //receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
        }

        /// <summary>
        /// Requests API service to update specific object.
        /// </summary>
        /// <param name="accessToken">Authorization access token.</param>
        /// <param name="uri">API service address.</param>
        /// <param name="model">Object.</param>
        /// <returns>API service response.</returns>
        internal static async Task<string> PutAsync(string accessToken, string uri, object model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                string json = JsonConvert.SerializeObject(model, Formatting.Indented);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await httpClient.PutAsync(uri, httpContent))
                {
                    return await response.Content.ReadAsStringAsync();
                    // returns object, todo: change response in api to return successfull message

                }
            }
        }

        /// <summary>
        /// Requests API service to delete specific object.
        /// </summary>
        /// <param name="accessToken">Authorization access token.</param>
        /// <param name="uri">API service address.</param>
        /// <returns>API service response.</returns>
        internal static async Task<string> DeleteAsync(string accessToken, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                using (HttpResponseMessage response = await httpClient.DeleteAsync(uri))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

    }
}
