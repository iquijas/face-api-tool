using FaceAPITool.Domain;
using FaceAPITool.Domain.Face;
using FaceAPITool.Interfaces.Face;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceAPITool.Helpers
{
    public class FaceHelper : FaceAPIHelperBase, IFaceHelper
    {
        public FaceHelper(string faceAPIKey, string faceAPIZone) : base(faceAPIKey, faceAPIZone)
        {
        }

        public async Task<List<DetectResult>> DetectAsync(string url, string returnFaceAttributes, bool returnFaceId = false, bool returnFaceLandmarks = false)
        {
            dynamic body = new JObject();
            body.url = url;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId={returnFaceId}&returnFaceLandmarks={returnFaceLandmarks}&returnFaceAttributes={returnFaceAttributes}", queryString);

                List<DetectResult> result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<DetectResult>>(json);
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

        public async Task<List<FindSimilarResult>> FindSimilarAsync(string faceId, string faceListId, string largeFaceListId, string[] faceIds, int maxNumOfCandidatesReturned, string mode)
        {
            dynamic body = new JObject();
            body.faceId = faceId;

            if (faceListId != string.Empty)
                body.faceListId = faceListId;

            if(largeFaceListId != string.Empty)
                body.largeFaceListId = largeFaceListId;

            if (faceIds.Length > 0)
                body.faceIds = JArray.FromObject(faceIds);

            body.maxNumOfCandidatesReturned = maxNumOfCandidatesReturned;
            body.mode = mode;
            StringContent queryString = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.FaceAPIKey);
                var response = await client.PostAsync($"https://{this.FaceAPIZone}.api.cognitive.microsoft.com/face/v1.0/findsimilars", queryString);

                List<FindSimilarResult> result = null;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<FindSimilarResult>>(json);
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