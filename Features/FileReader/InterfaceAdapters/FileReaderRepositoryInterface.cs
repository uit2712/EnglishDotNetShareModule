
using Core.Models;

namespace Core.Features.FileReader.InterfaceAdapters;

public interface FileReaderRepositoryInterface
{
    public Result<IEnumerable<T>> ReadAsArray<T>(string path);
}