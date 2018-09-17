using FaceAPITool.Domain.FaceList;
using FaceAPITool.Helpers;
using FaceAPITool.Tests.Fixtures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace FaceAPITool.Tests
{
    public class FaceListTests : IClassFixture<FaceAPISettingsFixture>
    {
        private FaceAPISettingsFixture faceAPISettingsFixture = null;

        public FaceListTests(FaceAPISettingsFixture fixture)
        {
            faceAPISettingsFixture = fixture;
        }

        [Fact]
        public void AddFaceAsyncTest()
        {
            AddFaceResult result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
        public void ListAsyncTest()
        {
            List<ListResult> result = null;
            var list_identifier = System.Guid.NewGuid().ToString();
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(list_identifier, list_identifier, list_identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.ListAsync().Result;
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
        public void UpdateAsyncTest()
        {
            bool result = false;
            var list_identifier = System.Guid.NewGuid().ToString();
            FaceListHelper helper = new FaceListHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

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
    }
}