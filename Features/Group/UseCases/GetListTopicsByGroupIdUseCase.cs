using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;

namespace Core.Features.Group.UseCases;

public class GetListTopicsByGroupIdUseCase
{
    private CachedTopicRepositoryInterface topic;

    public GetListTopicsByGroupIdUseCase(CachedTopicRepositoryInterface topic)
    {
        this.topic = topic;
    }

    public async Task<GetListTopicsResult> Invoke(int? id)
    {
        var validId = id.HasValue ? id.Value : 0;

        return await topic.GetByGroupId(validId);
    }
}