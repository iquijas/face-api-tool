using FaceAPITool.Domain.FaceList;
using FaceAPITool.Interfaces.FaceList;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceAPITool.Helpers
{
    public class FaceListHelper : FaceAPIHelperBase, IFaceList
    {
        public FaceListHelper(string faceAPIKey, string faceAPIZone) : base(faceAPIKey, faceAPIZone)
        {
        }

        public async Task<AddFaceResult> AddFaceAsync(string faceListId, string url, string userData, string targetFace)
        {
            dynamic body = new JObject();
            body.url = url;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}/persistedFaces?userData={userData}&targetFace={targetFace}", queryString);

                AddFaceResult result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AddFaceResult>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<bool> CreateAsync(string faceListId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PutAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}", queryString);

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }
                return result;
            }
        }

        public async Task<bool> DeleteAsync(string faceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.DeleteAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}");

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }
                return result;
            }
        }

        public async Task<bool> DeleteFaceAsync(string faceListId, string persistedFaceId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.DeleteAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}/persistedfaces/{persistedFaceId}");

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<GetResult> GetAsync(string faceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}");

                GetResult result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetResult>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<List<ListResult>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists");

                List<ListResult> result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<ListResult>>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<bool> UpdateAsync(string faceListId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PatchAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}", queryString);

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }
    }
}