using Core.Features.Group.Entities;
using Core.Models;

namespace Core.Features.Group.Models;

public class GetListGroupsResult : Result<IEnumerable<GroupEntity>>
{
}