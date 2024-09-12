using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.UseCases;
using Core.Models;

namespace Core.Features.Topic.DependencyInjection;

public class TopicDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<Result<IEnumerable<TopicEntity>>, GetListTopicsResult>();
        services.AddScoped<TopicRepositoryInterface, TopicRepository>();
        services.AddScoped<CachedTopicRepositoryInterface, CachedTopicRepository>();
        services.AddScoped<DataFileImporterRepositoryInterface<Result<IEnumerable<TopicEntity>>>, TopicFileImporterRepository>();
        services.AddScoped<SeedDataFromFileRepositoryInterface<TopicEntity>, SeedTopicFromFileRepository>();

        services.AddScoped<GetListVocabulariesByTopicIdUseCase, GetListVocabulariesByTopicIdUseCase>();
        services.AddScoped<UpdateTopicUseCase, UpdateTopicUseCase>();
        services.AddScoped<GetTopicByIdUseCase, GetTopicByIdUseCase>();
        services.AddScoped<SeedDataFromFileUseCase<TopicEntity>, SeedTopicsFromFileUseCase>();
        services.AddScoped<GetTopicsFromFileUseCase, GetTopicsFromFileUseCase>();
    }
}