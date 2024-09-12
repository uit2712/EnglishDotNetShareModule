using Core.Constants;
using Core.Context;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Vocabulary.Repositories;

public class VocabularyRepository : VocabularyRepositoryInterface
{
    private IEnglishContext _context;
    private string _itemName = "vocabulary";

    public VocabularyRepository(IEnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListVocabulariesResult> GetAll()
    {
        var result = new GetListVocabulariesResult
        {
            Data = await _context.Vocabularies.ToListAsync()
        };
        if (null == result.Data)
        {
            result.Message = "Get all vocabularies failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get all vocabularies success";
        return result;
    }

    public async Task<GetVocabularyResult> Get(long id)
    {
        var result = new GetVocabularyResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        result.Data = await _context.Vocabularies.FirstOrDefaultAsync(item => item.Id == id);
        if (null == result.Data)
        {
            result.Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName);
            return result;
        }

        result.Success = true;
        result.Message = string.Format(SuccessMessage.FOUND_ITEM, _itemName);
        return result;
    }

    public async Task<GetListVocabulariesResult> GetByTopicId(long topicId)
    {
        var result = new GetListVocabulariesResult();
        if (topicId <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "topicId");
            return result;
        }

        result.Data = await _context.Vocabularies.Where(item => item.TopicId == topicId).ToListAsync();
        result.Success = result.Data.Count() > 0;
        if (result.Success)
        {
            result.Message = string.Format(SuccessMessage.FOUND_LIST_ITEMS, _itemName);
        }
        else
        {
            result.Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName);
        }
        return result;
    }
}