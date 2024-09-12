using Core.Features.Group.InterfaceAdapters;
using Core.Models;

namespace Core.Features.Group.UseCases;

public class SeedGroupsFromFileUseCase
{
    private SeedGroupFromFileRepositoryInterface seeder;

    public SeedGroupsFromFileUseCase(SeedGroupFromFileRepositoryInterface seeder)
    {
        this.seeder = seeder;
    }

    public Result<bool> Invoke()
    {
        return seeder.Seed();
    }
}