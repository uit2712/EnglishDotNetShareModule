using Core.Features.Group.InterfaceAdapters;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Group.Repositories;

public class SeedGroupFromFileRepository : SeedGroupFromFileRepositoryInterface
{
    private GroupFileImporterRepositoryInterface fileImporter;
    private EnglishContext.EnglishContext context;

    public SeedGroupFromFileRepository(GroupFileImporterRepositoryInterface fileImporter, EnglishContext.EnglishContext context)
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
            if (context.Groups.Any())
            {
                result.Message = "Already seed data";
                return result;
            }

            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups ON;");
                context.Groups.AddRange(getDataResult.Data);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups OFF;");
                transaction.Commit();
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