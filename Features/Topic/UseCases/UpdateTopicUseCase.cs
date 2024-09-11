using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;

namespace Core.Features.Topic.UseCases;

public class UpdateTopicUseCase
{
    private CachedTopicRepositoryInterface _topic;

    public UpdateTopicUseCase(CachedTopicRepositoryInterface topic)
    {
        _topic = topic;
    }

    public async Task<GetTopicResult> Invoke(int id, string name)
    {
        return await _topic.UpdateTopicName(id, name);
    }
}