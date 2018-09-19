using FaceAPITool.Domain.Face;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceAPITool.Interfaces.Face
{
    public interface IFaceHelper
    {
        Task<List<DetectResult>> DetectAsync(string url, string returnFaceAttributes, bool returnFaceId = false, bool returnFaceLandmarks = false);

        Task<List<FindSimilarResult>> FindSimilarAsync(string faceId, string faceListId, string largeFaceListId, string[] faceIds, int maxNumOfCandidatesReturned, string mode);
    }
}