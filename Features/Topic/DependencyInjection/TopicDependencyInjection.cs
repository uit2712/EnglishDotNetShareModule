using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.UseCases;
using Core.Models;

namespace Core.Features.Topic.DependencyInjection;

public class TopicDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<TopicRepositoryInterface, TopicRepository>();
        services.AddScoped<CachedTopicRepositoryInterface, CachedTopicRepository>();

        services.AddScoped<GetListVocabulariesByTopicIdUseCase, GetListVocabulariesByTopicIdUseCase>();
        services.AddScoped<UpdateTopicUseCase, UpdateTopicUseCase>();
        services.AddScoped<GetTopicByIdUseCase, GetTopicByIdUseCase>();
    }
}