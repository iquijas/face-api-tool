using FaceAPITool.Domain.LargePersonGroup;
using FaceAPITool.Helpers;
using FaceAPITool.Tests.Fixtures;
using System.Collections.Generic;
using Xunit;

namespace FaceAPITool.Tests
{
    public class LargePersonGroupHelperTests : IClassFixture<FaceAPISettingsFixture>
    {
        private FaceAPISettingsFixture faceAPISettingsFixture = null;

        public LargePersonGroupHelperTests(FaceAPISettingsFixture fixture)
        {
            faceAPISettingsFixture = fixture;
        }

        [Fact]
        public void CreateAsyncTest()
        {
            bool result = false;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {result}");
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

            Assert.True(result != false);
        }

        [Fact]
        public void DeleteAsyncTest()
        {
            bool result = false;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.DeleteAsync(identifier).Result;
                System.Diagnostics.Trace.Write($"Deletion Result: {result}");
            }
            catch
            {
                throw;
            }

            Assert.True(result != false);
        }

        [Fact]
        public void GetAsyncTest()
        {
            GetResult result = null;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.GetAsync(identifier).Result;
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
        }

        [Fact]
        public void GetTrainingStatusAsyncTest()
        {
            GetTrainingStatusResult result = null;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                bool training_result = false;
                training_result = helper.TrainAsync(identifier).Result;
                System.Diagnostics.Trace.Write($"Train Result: {training_result}");

                if (training_result)
                    result = helper.GetTrainingStatusAsync(identifier).Result;
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
        }

        [Fact]
        public void ListAsyncTest()
        {
            List<ListResult> result = null;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.ListAsync(string.Empty, 1000).Result;
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
        }

        [Fact]
        public void TrainAsyncTest()
        {
            bool result = false;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                result = helper.TrainAsync(identifier).Result;
                System.Diagnostics.Trace.Write($"Train Result: {result}");
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

            Assert.True(result != false);
        }

        [Fact]
        public void UpdateAsyncTest()
        {
            bool result = false;
            var identifier = System.Guid.NewGuid().ToString();
            LargePersonGroupHelper helper = new LargePersonGroupHelper(faceAPISettingsFixture.FaceAPIKey, faceAPISettingsFixture.FaceAPIZone);

            try
            {
                var creation_result = helper.CreateAsync(identifier, identifier, identifier).Result;
                System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                if (creation_result)
                    result = helper.UpdateAsync(identifier, "Name", "User Data Sample").Result;
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

            Assert.True(result != false);
        }
    }
}