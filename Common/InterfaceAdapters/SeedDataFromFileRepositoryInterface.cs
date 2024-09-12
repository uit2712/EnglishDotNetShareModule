using Core.Models;

namespace Core.Common.InterfaceAdapters;

public interface SeedDataFromFileRepositoryInterface<T>
{
    public Result<bool> Seed(IEnumerable<T> list);
}