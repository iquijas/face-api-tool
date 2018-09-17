using FaceAPITool.Domain;
using FaceAPITool.Domain.LargePersonGroup;
using FaceAPITool.Interfaces.LargePersonGroup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceAPITool.Helpers
{
    public class LargePersonGroupHelper : FaceAPIHelperBase, ILargePersonGroup
    {
        public LargePersonGroupHelper(string faceAPIKey, string faceAPIZone) : base(faceAPIKey, faceAPIZone)
        {
        }

        public async Task<bool> CreateAsync(string largePersonGroupId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PutAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}", queryString);

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }
                return result;
            }
        }

        public async Task<bool> DeleteAsync(string largePersonGroupId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.DeleteAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}");

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }
                return result;
            }
        }

        public async Task<GetResult> GetAsync(string largePersonGroupId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}");

                GetResult result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetResult>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }

                return result;
            }
        }

        public async Task<GetTrainingStatusResult> GetTrainingStatusAsync(string largePersonGroupId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}/training");

                GetTrainingStatusResult result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetTrainingStatusResult>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }

                return result;
            }
        }

        public async Task<List<ListResult>> ListAsync(string start, int top)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.GetAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups?start={start}&top={top}");

                List<ListResult> result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<ListResult>>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }

                return result;
            }
        }

        public async Task<bool> TrainAsync(string largePersonGroupId)
        {
            dynamic body = new JObject();
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}/train", queryString);

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }

                return result;
            }
        }

        public async Task<bool> UpdateAsync(string largePersonGroupId, string name, string userData)
        {
            dynamic body = new JObject();
            body.name = name;
            body.userData = userData;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PatchAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/largepersongroups/{largePersonGroupId}", queryString);

                bool result = false;
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    NotSuccessfulResponse fex = JsonConvert.DeserializeObject<NotSuccessfulResponse>(json);
                    throw new Exception($"{fex.error.code} - {fex.error.message}");
                }

                return result;
            }
        }
    }
}