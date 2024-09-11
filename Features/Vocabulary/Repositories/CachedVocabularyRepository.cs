using Core.Constants;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Features.Vocabulary.Repositories;

public class CachedVocabularyRepository : CachedVocabularyRepositoryInterface
{
    private VocabularyRepositoryInterface _db;
    private IDistributedCache _cache;
    private string GROUP_CACHE = "Vocabularies";

    public CachedVocabularyRepository(VocabularyRepositoryInterface db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<GetListVocabulariesResult> GetAll()
    {
        var result = new GetListVocabulariesResult();
        var keyCache = GetAllKeyCache();
        var cachedData = await _cache.GetAsync(keyCache);

        if (cachedData != null)
        {
            var data = CacheHelper.Decode<IEnumerable<VocabularyEntity>>(cachedData);
            result.Success = true;
            result.Message = "Get all vocabularies from cache succes";
            result.Data = data;

            return result;
        }

        result = await _db.GetAll();
        if (result.Success)
        {
            await _cache.SetAsync(keyCache, CacheHelper.Encode(result.Data));
        }

        return result;
    }

    private string GetAllKeyCache()
    {
        return string.Format("{0}:ALL", GROUP_CACHE);
    }

    public async Task<GetVocabularyResult> Get(long id)
    {
        var result = new GetVocabularyResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        var keyCache = GetIdKeyCache(id);
        var cachedData = await _cache.GetAsync(keyCache);

        if (cachedData != null)
        {
            var data = CacheHelper.Decode<VocabularyEntity>(cachedData);
            result.Success = true;
            result.Message = "Get vocabulary by id from cache succes";
            result.Data = data;

            return result;
        }

        result = await _db.Get(id);
        if (result.Success)
        {
            await _cache.SetAsync(keyCache, CacheHelper.Encode(result.Data));
        }

        return result;
    }

    public string GetIdKeyCache(long id)
    {
        return string.Format("{0}:{1}", GROUP_CACHE, id);
    }

    public async Task<GetListVocabulariesResult> GetByTopicId(int topicId)
    {
        var result = new GetListVocabulariesResult();
        if (topicId <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "topicId");
            return result;
        }

        var keyCache = GetTopicIdKeyCache(topicId);
        var cachedData = await _cache.GetAsync(keyCache);

        IEnumerable<long> listIds = new List<long>();
        if (cachedData != null)
        {
            var listIdsFromCache = CacheHelper.Decode<List<long>>(cachedData);
            if (null != listIdsFromCache && listIdsFromCache.Count() > 0)
            {
                listIds = listIdsFromCache;
            }
        }

        if (listIds.Count() > 0)
        {
            var getListVocabulariesResults = await Task.WhenAll(listIds.Select(Get));

            result.Success = true;
            result.Message = "Get list vocabularies by topic id from cache succes";
            result.Data = getListVocabulariesResults.Where(item => item.isHasData()).Select(item => item.Data).ToList();

            return result;
        }

        result = await _db.GetByTopicId(topicId);
        if (result.isHasData() && result.Data?.Count() > 0)
        {
            listIds = result.Data.Select(item => item.Id);
            await _cache.SetAsync(keyCache, CacheHelper.Encode(listIds));
            await Task.WhenAll(result.Data.Select(item => _cache.SetAsync(GetIdKeyCache(item.Id), CacheHelper.Encode(item))));
        }

        return result;
    }

    private string GetTopicIdKeyCache(long id)
    {
        return string.Format("{0}:TopicId:{1}", GROUP_CACHE, id);
    }
}