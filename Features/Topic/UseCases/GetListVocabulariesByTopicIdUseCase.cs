using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Core.Features.Vocabulary.InterfaceAdapters;

namespace Core.Features.Topic.UseCases;

public class GetListVocabulariesByTopicIdUseCase
{
    private CachedTopicRepositoryInterface _topic;
    private CachedVocabularyRepositoryInterface _voca;

    public GetListVocabulariesByTopicIdUseCase(
        CachedVocabularyRepositoryInterface voca,
        CachedTopicRepositoryInterface topic)
    {
        _voca = voca;
        _topic = topic;
    }

    public async Task<GetListVocabulariesByTopicIdResult> Invoke(int topicId)
    {
        var result = new GetListVocabulariesByTopicIdResult();

        var getTopicResult = await _topic.Get(topicId);
        if (getTopicResult.isHasData() == false)
        {
            result.Message = getTopicResult.Message;
            return result;
        }

        result.Topic = getTopicResult.Data;

        var getListVocabulariesResult = await _voca.GetByTopicId(topicId);
        if (getListVocabulariesResult.isHasData())
        {
            result.Success = true;
            result.Data = getListVocabulariesResult.Data;
            result.Message = getListVocabulariesResult.Message;
        }

        return result;
    }
}