using Core.Models;

namespace Core.Features.Topic.InterfaceAdapters;

public interface SeedTopicFromFileRepositoryInterface
{
    public Result<bool> Seed();
}