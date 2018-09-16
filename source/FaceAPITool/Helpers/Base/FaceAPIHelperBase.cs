namespace FaceAPITool.Helpers
{
    public class FaceAPIHelperBase
    {
        public string FaceAPIKey { get; set; }
        public string FaceAPIZone { get; set; }

        public FaceAPIHelperBase(string faceAPIKey, string faceAPIZone)
        {
            FaceAPIKey = faceAPIKey;
            FaceAPIZone = faceAPIZone;
        }
    }
}