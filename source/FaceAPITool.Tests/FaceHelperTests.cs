using FaceAPITool.Domain.Face;
using FaceAPITool.Domain.FaceList;
using FaceAPITool.Helpers;
using FaceAPITool.Tests.Fixtures;
using FaceAPITool.Tests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace FaceAPITool.Tests
{
    public class FaceHelperTests : IClassFixture<FaceAPISettingsFixture>
    {
        private FaceAPISettingsFixture faceAPISettingsFixture = null;

        public FaceHelperTests(FaceAPISettingsFixture fixture)
        {
            faceAPISettingsFixture = fixture;
        }

        [Fact]
        public void DetectAsyncTest()
        {
            TestsHelper.CompletesIn(5, () =>
            {
                List<DetectResult> result = null;
                FaceHelper helper = new FaceHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

                try
                {
                    result = helper.DetectAsync(faceAPISettingsFixture.TestImageUrl, "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise", true, true).Result;
                }
                catch
                {
                    throw;
                }

                Assert.True(result != null);
            });
        }

        [Fact]
        public void FindSimilarAsyncTest()
        {
            TestsHelper.CompletesIn(5, () =>
            {
                List<FindSimilarResult> result = null;
                var identifier = System.Guid.NewGuid().ToString();
                FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);
                FaceHelper face_helper = new FaceHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

                try
                {
                    var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    AddFaceResult addface_result = null;
                    if (creation_result)
                    {
                        dynamic jUserData = new JObject();
                        jUserData.UserDataSample = "User Data Sample";
                        var rUserData = JsonConvert.SerializeObject(jUserData);

                        addface_result = helper.AddFaceAsync(identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;

                        if (addface_result != null)
                        {
                            List<DetectResult> detection_result = face_helper.DetectAsync(faceAPISettingsFixture.TestImageUrl, "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise", true, true).Result;

                            if (detection_result != null)
                                result = face_helper.FindSimilarAsync(detection_result[0].faceId, identifier, string.Empty, new string[] { }, 10, "matchPerson").Result;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = helper.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result != null);
            });
        }
    }
}