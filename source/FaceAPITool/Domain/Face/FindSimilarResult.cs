namespace FaceAPITool.Domain.Face
{
    public class FindSimilarResult
    {
        public string persistedFaceId { get; set; }
        public float confidence { get; set; }
    }
}