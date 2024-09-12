using Core.Features.Group.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Core.Seed;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Core.EnglishContext.EnglishContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Core.EnglishContext.EnglishContext>>()))
        {
            SeedDataGroups(serviceProvider, context);
        }
    }

    private static void SeedDataGroups(IServiceProvider serviceProvider, Core.EnglishContext.EnglishContext context)
    {
        if (context == null || context.Groups == null)
        {
            throw new ArgumentNullException("Null RazorPagesMovieContext");
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
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups ON;");
                    context.Groups.AddRange(data);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.groups OFF;");
                    transaction.Commit();
                }
            }
        }
    }
}