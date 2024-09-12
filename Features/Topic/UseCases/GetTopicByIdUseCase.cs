using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;

namespace Core.Features.Topic.UseCases;

public class GetTopicByIdUseCase
{
    private CachedTopicRepositoryInterface _topic;

    public GetTopicByIdUseCase(CachedTopicRepositoryInterface topic)
    {
        _topic = topic;
    }

    public async Task<GetTopicResult> Invoke(int? id)
    {
        var validId = id.HasValue ? id.Value : 0;

        return await _topic.Get(validId);
    }
}