using FaceAPITool.Domain.Face;
using FaceAPITool.Interfaces.Face;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceAPITool.Helpers
{
    public class FaceHelper : FaceAPIHelperBase, IFace
    {
        public FaceHelper(string faceAPIKey, string faceAPIZone) : base(faceAPIKey, faceAPIZone)
        {
        }

        public async Task<List<FindSimilarResult>> FindSimilarAsync(string largeFaceListId, string faceId, int maxNumOfCandidatesReturned)
        {
            dynamic body = new JObject();
            body.faceId = faceId;
            body.largeFaceListId = largeFaceListId;
            body.maxNumOfCandidatesReturned = maxNumOfCandidatesReturned;
            body.mode = "matchPerson";
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
                return result;
            }
        }
    }
}