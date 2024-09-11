using Core.Features.Vocabulary.Entities;
using Core.Models;

namespace Core.Features.Vocabulary.Models;

public class GetListVocabulariesResult : Result<IEnumerable<VocabularyEntity>>
{
    public GetListVocabulariesResult()
    {
        this.Data = [];
    }
}