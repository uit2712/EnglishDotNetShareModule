using Core.Common.InterfaceAdapters;
using Core.Features.Vocabulary.Entities;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Vocabulary.Repositories;

public class SeedVocabularyFromFileRepository : SeedDataFromFileRepositoryInterface<VocabularyEntity>
{
    private EnglishContext.EnglishContext context;

    public SeedVocabularyFromFileRepository(EnglishContext.EnglishContext context)
    {
        this.context = context;
    }

    public Result<bool> Seed(IEnumerable<VocabularyEntity> list)
    {
        var result = new Result<bool>();
        if (list.Count() == 0)
        {
            result.Message = "List is empty";
            return result;
        }

        using (var transaction = context.Database.BeginTransaction())
        {
            if (context.Vocabularies.Any())
            {
                result.Message = "Already seed data";
                return result;
            }

            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.vocabularies ON;");
                context.Vocabularies.AddRange(list);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.vocabularies OFF;");
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