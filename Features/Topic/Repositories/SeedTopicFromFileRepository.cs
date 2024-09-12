using Core.Features.Topic.InterfaceAdapters;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Topic.Repositories;

public class SeedTopicFromFileRepository : SeedTopicFromFileRepositoryInterface
{
    private TopicFileImporterRepositoryInterface fileImporter;
    private EnglishContext.EnglishContext context;

    public SeedTopicFromFileRepository(TopicFileImporterRepositoryInterface fileImporter, EnglishContext.EnglishContext context)
    {
        this.fileImporter = fileImporter;
        this.context = context;
    }

    public Result<bool> Seed()
    {
        var result = new Result<bool>();
        var getDataResult = fileImporter.GetAll();

        if (false == getDataResult.Success || null == getDataResult.Data)
        {
            result.Message = getDataResult.Message;
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
                context.Topics.AddRange(getDataResult.Data);
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