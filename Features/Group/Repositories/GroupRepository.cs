using Core.Constants;
using Core.Context;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Group.Repositories;

public class GroupRepository : GroupRepositoryInterface
{
    private IEnglishContext _context;

    public GroupRepository(IEnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListGroupsResult> GetAll()
    {
        var result = new GetListGroupsResult
        {
            Success = true,
            Data = await _context.Groups.ToListAsync(),
            Message = "Get all groups success"
        };

        return result;
    }
    public async Task<GetGroupResult> Get(int id)
    {
        var result = new GetGroupResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        result.Data = await _context.Groups.FirstOrDefaultAsync(item => item.Id == id);
        result.Success = null != result.Data;
        if (result.Success)
        {
            result.Message = string.Format(SuccessMessage.FOUND_ITEM, "group");
        }
        else
        {
            result.Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, "group");
        }

        return result;
    }
    public async Task<GetGroupResult> Update(GroupEntity? data)
    {
        var result = new GetGroupResult();
        if (null == data)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "data");
            return result;
        }

        if (data.Id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        result = await Get(data.Id);
        if (false == result.Success || null == result.Data)
        {
            return result;
        }

        if (string.IsNullOrEmpty(data.Name) == false)
        {
            result.Data.Name = data.Name.Trim();
        }

        var totalUpdatedItems = _context.SaveChanges();

        result.Success = totalUpdatedItems > 0;
        if (result.Success)
        {
            result.Message = "Update group success";
        }
        else
        {
            result.Message = "Update group failed";
        }

        return result;
    }
}