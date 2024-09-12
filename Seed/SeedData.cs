using Core.Features.Group.InterfaceAdapters;
using Core.Features.Topic.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Core.Seed;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new EnglishContext.EnglishContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<EnglishContext.EnglishContext>>()))
        {
            SeedDataGroups(serviceProvider, context);
            SeedDataTopics(serviceProvider, context);
        }
    }

    private static void SeedDataGroups(IServiceProvider serviceProvider, EnglishContext.EnglishContext context)
    {
        if (context == null || context.Groups == null)
        {
            return;
        }

        // Look for any movies.
        if (context.Groups.Any())
        {
            return;   // DB has been seeded
        }

        var fileImporter = serviceProvider.GetService<GroupFileImporterRepositoryInterface>();

        if (null != fileImporter)
        {
            var data = fileImporter.GetAll().Data;
            if (null != data)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups ON;");
                        context.Groups.AddRange(data);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups OFF;");
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }

    private static void SeedDataTopics(IServiceProvider serviceProvider, Core.EnglishContext.EnglishContext context)
    {
        if (context == null || context.Topics == null)
        {
            return;
        }

        // Look for any movies.
        if (context.Topics.Any())
        {
            return;   // DB has been seeded
        }

        var fileImporter = serviceProvider.GetService<TopicFileImporterRepositoryInterface>();

        if (null != fileImporter)
        {
            var data = fileImporter.GetAll().Data;
            if (null != data)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics ON;");
                        context.Topics.AddRange(data);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.topics OFF;");
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}