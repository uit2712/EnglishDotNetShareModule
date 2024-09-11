using Core.Features.Topic.Entities;
using Core.Features.Vocabulary.Entities;
using Core.Models;

namespace Core.Features.Topic.Models;

public class GetListVocabulariesByTopicIdResult : Result<IEnumerable<VocabularyEntity>>
{
    public TopicEntity? Topic { get; set; }
}