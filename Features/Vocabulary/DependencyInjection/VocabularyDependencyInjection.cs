using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Repositories;

namespace Core.Features.Vocabulary.DependencyInjection;

public class VocabularyDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<VocabularyRepositoryInterface, VocabularyRepository>();
        services.AddScoped<CachedVocabularyRepositoryInterface, CachedVocabularyRepository>();
    }
}