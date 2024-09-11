using Core.Features.Topic.Models;

namespace Core.Features.Topic.InterfaceAdapters;

public interface TopicRepositoryInterface
{
    public Task<GetListTopicsResult> GetAll();
    public Task<GetTopicResult> Get(int id);
    public Task<GetTopicResult> UpdateTopicName(int id, string name);
    public Task<GetListTopicsResult> GetByGroupId(int groupId);
}