using Core.Features.Vocabulary.Models;

namespace Core.Features.Vocabulary.InterfaceAdapters;

public interface CachedVocabularyRepositoryInterface
{
    public Task<GetListVocabulariesResult> GetAll();
    public Task<GetVocabularyResult> Get(long id);
    public string GetIdKeyCache(long id);
    public Task<GetListVocabulariesResult> GetByTopicId(int topicId);
}