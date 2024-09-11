using Core.Constants;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Features.Group.Repositories;

public class CachedGroupRepository : CachedGroupRepositoryInterface
{
    private GroupRepositoryInterface _db;
    private IDistributedCache _cache;
    private string GROUP_CACHE = "Groups";

    public CachedGroupRepository(GroupRepositoryInterface db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<GetListGroupsResult> GetAll()
    {
        var result = new GetListGroupsResult();
        var keyCache = GetAllKeyCache();
        var cachedData = await _cache.GetAsync(keyCache);

        IEnumerable<int> listIds = new List<int>();
        if (cachedData != null)
        {
            var listIdsFromCache = CacheHelper.Decode<List<int>>(cachedData);
            if (null != listIdsFromCache && listIdsFromCache.Count() > 0)
            {
                listIds = listIdsFromCache;
            }
        }

        if (listIds.Count() > 0)
        {
            var getDataResults = await Task.WhenAll(listIds.Select(id => Get(id)));

            result.Success = true;
            result.Message = "Get all groups from cache succes";
            result.Data = getDataResults.Where(item => item.isHasData()).Select(item => item.Data).ToList();

            return result;
        }

        result = await _db.GetAll();
        if (result.isHasData() && result.Data?.Count() > 0)
        {
            listIds = result.Data.Select(item => item.Id);
            await _cache.SetAsync(keyCache, CacheHelper.Encode(listIds));
            await Task.WhenAll(result.Data.Select(item => _cache.SetAsync(GetIdKeyCache(item.Id), CacheHelper.Encode(item))));
        }

        return result;
    }

    public string GetAllKeyCache()
    {
        return string.Format("{0}:ALL", GROUP_CACHE);
    }

    public async Task<GetGroupResult> Get(int id)
    {
        var result = new GetGroupResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        var keyCache = GetIdKeyCache(id);
        var cachedData = await _cache.GetAsync(keyCache);

        if (cachedData != null)
        {
            var data = CacheHelper.Decode<GroupEntity>(cachedData);
            result.Success = true;
            result.Message = "Get Group by id from cache succes";
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

    public string GetIdKeyCache(int id)
    {
        return string.Format("{0}:{1}", GROUP_CACHE, id);
    }

    public async Task<GetGroupResult> Update(GroupEntity? data)
    {
        var updateResult = await _db.Update(data);
        if (null != data && updateResult.Success)
        {
            await _cache.RemoveAsync(GetIdKeyCache(data.Id));
        }

        return updateResult;
    }
}