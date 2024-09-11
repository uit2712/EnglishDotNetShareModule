
using Core.Features.Group.Entities;
using Core.Features.Group.Models;

namespace Core.Features.Group.InterfaceAdapters;

public interface CachedGroupRepositoryInterface
{
    public Task<GetListGroupsResult> GetAll();
    public Task<GetGroupResult> Get(int id);
    public string GetIdKeyCache(int id);
    public Task<GetGroupResult> Update(GroupEntity data);
}