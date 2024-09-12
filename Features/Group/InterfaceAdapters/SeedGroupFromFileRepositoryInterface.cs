using Core.Models;

namespace Core.Features.Group.InterfaceAdapters;

public interface SeedGroupFromFileRepositoryInterface
{
    public Result<bool> Seed();
}