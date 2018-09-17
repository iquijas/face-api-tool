using FaceAPITool.Domain.LargeFaceList;
using FaceAPITool.Helpers;
using FaceAPITool.Tests.Fixtures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace FaceAPITool.Tests
{
    public class LargeFaceListTests : IClassFixture<FaceAPISettingsFixture>
    {
        private FaceAPISettingsFixture faceAPISettingsFixture = null;

        public LargeFaceListTests(FaceAPISettingsFixture fixture)
        {
            faceAPISettingsFixture = fixture;
        }

        [Fact]
        public void AddFaceAsyncTest()
        {
            AddFaceResult result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != null);
        }

        [Fact]
        public void CreateAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {result}");
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != false);
        }

        [Fact]
        public void DeleteAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {result}");
            }
            catch
            {
                throw;
            }

            Assert.True(result != false);
        }

        [Fact]
        public void DeleteFaceAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }

                result = helper.DeleteFaceAsync(list_identifier, addface_result.persistedFaceId).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != false);
        }

        [Fact]
        public void GetAsyncTest()
        {
            GetResult result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.GetAsync(list_identifier).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != null);
        }

        [Fact]
        public void GetFaceAsyncTest()
        {
            GetFaceResult result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }

                result = helper.GetFaceAsync(list_identifier, addface_result.persistedFaceId).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != null);
        }

        [Fact]
        public void GetTrainingStatusAsyncTest()
        {
            string result = string.Empty;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }

                bool training_result = false;
                training_result = helper.TrainAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Train Result: {training_result}");

                if (training_result)
                    result = helper.GetTrainingStatusAsync(list_identifier).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != string.Empty);
        }

        [Fact]
        public void ListAsyncTest()
        {
            List<ListResult> result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.ListAsync(string.Empty, 1000).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != null);
        }

        [Fact]
        public void ListFaceAsyncTest()
        {
            List<ListFaceResult> result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }

                result = helper.ListFaceAsync(list_identifier).Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != null);
        }

        [Fact]
        public void TrainAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                }

                result = helper.TrainAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Train Result: {result}");
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != false);
        }

        [Fact]
        public void UpdateAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                if (creation_result)
                    result = helper.UpdateAsync(list_identifier, "Name", "User Data Sample").Result;
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != false);
        }

        [Fact]
        public void UpdateFaceAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            LargeFaceListHelper helper = new LargeFaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                AddFaceResult addface_result = null;
                if (creation_result)
                {
                    dynamic jUserData = new JObject();
                    jUserData.UserDataSample = "User Data Sample";
                    var rUserData = JsonConvert.SerializeObject(jUserData);

                    addface_result = helper.AddFaceAsync(list_identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;

                    result = helper.UpdateFaceAsync(list_identifier, addface_result.persistedFaceId, "User Data Sample").Result;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                var deletion_result = helper.DeleteAsync(list_identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
            }

            Assert.True(result != false);
        }
    }
}