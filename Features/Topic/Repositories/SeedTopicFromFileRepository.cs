using Core.Common.InterfaceAdapters;
using Core.Features.Topic.Entities;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Topic.Repositories;

public class SeedTopicFromFileRepository : SeedDataFromFileRepositoryInterface<TopicEntity>
{
    private EnglishContext.EnglishContext context;

    public SeedTopicFromFileRepository(EnglishContext.EnglishContext context)
    {
        this.context = context;
    }

    public Result<bool> Seed(IEnumerable<TopicEntity> list)
    {
        var result = new Result<bool>();
        if (list.Count() == 0)
        {
            result.Message = "List is empty";
            return result;
        }

        using (var transaction = context.Database.BeginTransaction())
        {
            if (context.Topics.Any())
            {
                result.Message = "Already seed data";
                return result;
            }

            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics ON;");
                context.Topics.AddRange(list);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics OFF;");
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