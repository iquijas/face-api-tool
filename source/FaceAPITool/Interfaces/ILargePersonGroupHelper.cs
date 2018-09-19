using FaceAPITool.Domain.LargePersonGroup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceAPITool.Interfaces.LargePersonGroup
{
    public interface ILargePersonGroupHelper
    {
        Task<bool> CreateAsync(string largePersonGroupId, string name, string userData);

        Task<bool> DeleteAsync(string largePersonGroupId);

        Task<GetResult> GetAsync(string largePersonGroupId);

        Task<GetTrainingStatusResult> GetTrainingStatusAsync(string largePersonGroupId);

        Task<List<ListResult>> ListAsync(string start, int top);

        Task<bool> TrainAsync(string largePersonGroupId);

        Task<bool> UpdateAsync(string largePersonGroupId, string name, string userData);
    }
}