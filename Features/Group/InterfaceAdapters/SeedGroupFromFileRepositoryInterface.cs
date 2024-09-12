using Core.Features.Group.Entities;
using Core.Models;

namespace Core.Features.Group.InterfaceAdapters;

public interface SeedGroupFromFileRepositoryInterface
{
    public Result<bool> Seed(IEnumerable<GroupEntity> list);
}