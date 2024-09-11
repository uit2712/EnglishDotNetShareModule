using Core.Features.Topic.Entities;
using Core.Models;

namespace Core.Features.Topic.Models;

public class GetListTopicsResult : Result<IEnumerable<TopicEntity>>
{
    public GetListTopicsResult()
    {
        this.Data = [];
    }
}