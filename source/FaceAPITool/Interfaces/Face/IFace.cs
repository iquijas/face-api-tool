using FaceAPITool.Domain.Face;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceAPITool.Interfaces.Face
{
    public interface IFace
    {
        Task<List<FindSimilarResult>> FindSimilarAsync(string largeFaceListId, string faceId, int maxNumOfCandidatesReturned);
    }
}