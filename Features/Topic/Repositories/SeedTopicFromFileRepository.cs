using Core.Features.Topic.InterfaceAdapters;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

            // foreach (var item in getDataResult.Data)
            // {
            //     item.Id = -1;
            // }

            try
            {
                // context.Database.ExecuteSqlRaw("ALTER TABLE dbo.topics NOCHECK CONSTRAINT all;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics ON;");
                // context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups ON;");
                context.Topics.AddRange(getDataResult.Data);
                context.SaveChanges();
                // context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups OFF;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics OFF;");
                // context.Database.ExecuteSqlRaw("ALTER TABLE dbo.topics WITH CHECK CONSTRAINT all");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Detail = null != ex.InnerException ? ex.InnerException.Message : "";
                // result.Detail = JsonConvert.SerializeObject(getDataResult.Data);
            }
        }

        return result;
    }
}