using FaceAPITool.Domain.LargeFaceList;
using FaceAPITool.Interfaces.LargeFaceList;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceAPITool.Helpers
{
    public class LargeFaceListHelper : FaceAPIHelperBase, ILargeFaceList
    {
        public LargeFaceListHelper(string faceAPIKey, string faceAPIZone) : base(faceAPIKey, faceAPIZone)
        {
        }

        public async Task<AddFaceResult> AddFaceAsync(string largeFaceListId, string url, string userData, string targetFace)
        {
            dynamic body = new JObject();
            body.url = url;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/persistedFaces?userData={userData}&targetFace={targetFace}", queryString);

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

        public async Task<bool> CreateAsync(string largeFaceListId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PutAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}", queryString);

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

        public async Task<bool> DeleteAsync(string largeFaceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.DeleteAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}");

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

        public async Task<bool> DeleteFaceAsync(string largeFaceListId, string persistedFaceId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.DeleteAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/persistedfaces/{persistedFaceId}");

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

        public async Task<GetResult> GetAsync(string largeFaceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}");

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

        public async Task<GetFaceResult> GetFaceAsync(string largeFaceListId, string persistedFaceId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/persistedfaces/{persistedFaceId}");

                GetFaceResult result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetFaceResult>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<string> GetTrainingStatusAsync(string largeFaceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/training");

                string result = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    dynamic obj = JObject.Parse(json) as JObject;
                    result = obj.status;
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
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists?top=1000");

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

        public async Task<List<ListFaceResult>> ListFaceAsync(string largeFaceListId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/persistedfaces");

                List<ListFaceResult> result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<ListFaceResult>>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error code: {response.StatusCode}, {json}");
                }

                return result;
            }
        }

        public async Task<bool> TrainAsync(string largeFaceListId)
        {
            dynamic body = new JObject();
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/train", queryString);

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

        public async Task<bool> UpdateAsync(string largeFaceListId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PatchAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}", queryString);

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

        public async Task<bool> UpdateFaceAsync(string largeFaceListId, string persistedFaceId, string userData)
        {
            dynamic body = new JObject();
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PatchAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largefacelists/{largeFaceListId}/persistedfaces/{persistedFaceId}", queryString);

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