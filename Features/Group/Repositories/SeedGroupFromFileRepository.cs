using Core.Common.InterfaceAdapters;
using Core.Features.Group.Entities;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Group.Repositories;

public class SeedGroupFromFileRepository : SeedDataFromFileRepositoryInterface<GroupEntity>
{

    private EnglishContext.EnglishContext context;

    public SeedGroupFromFileRepository(EnglishContext.EnglishContext context)
    {
        this.context = context;
    }

    public Result<bool> Seed(IEnumerable<GroupEntity> list)
    {
        var result = new Result<bool>();
        if (list.Count() == 0)
        {
            result.Message = "List is empty";
            return result;
        }

        using (var transaction = context.Database.BeginTransaction())
        {
            if (context.Groups.Any())
            {
                result.Message = "Already seed data";
                return result;
            }

            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups ON;");
                context.Groups.AddRange(list);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups OFF;");
                transaction.Commit();

                result.Success = true;
                result.Message = "Seed data success";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Detail = null != ex.InnerException ? ex.InnerException.Message : "";
            }
        }

        return result;
    }
}