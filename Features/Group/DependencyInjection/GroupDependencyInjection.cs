using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Core.Features.Group.Repositories;
using Core.Features.Group.UseCases;
using Core.Models;

namespace Core.Features.Group.DependencyInjection;

public class GroupDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<Result<IEnumerable<GroupEntity>>, GetListGroupsResult>();
        services.AddScoped<DataFileImporterRepositoryInterface<Result<IEnumerable<GroupEntity>>>, GroupFileImporterRepository>();
        services.AddScoped<GroupRepositoryInterface, GroupRepository>();
        services.AddScoped<CachedGroupRepositoryInterface, CachedGroupRepository>();
        services.AddScoped<SeedDataFromFileRepositoryInterface<GroupEntity>, SeedGroupFromFileRepository>();

        services.AddScoped<GetAllGroupsUseCase, GetAllGroupsUseCase>();
        services.AddScoped<GetGroupByIdUseCase, GetGroupByIdUseCase>();
        services.AddScoped<GetListTopicsByGroupIdUseCase, GetListTopicsByGroupIdUseCase>();
        services.AddScoped<SeedDataFromFileUseCase<GroupEntity>, SeedGroupsFromFileUseCase>();
        services.AddScoped<GetDataFromFileUseCase<GroupEntity>, GetListGroupsFromFileUseCase>();
    }
}