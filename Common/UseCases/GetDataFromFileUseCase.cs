using Core.Common.InterfaceAdapters;
using Core.Models;

namespace Core.Common.UseCases;

public class GetDataFromFileUseCase<TEntity>
{
    private DataFileImporterRepositoryInterface<Result<IEnumerable<TEntity>>> db;

    public GetDataFromFileUseCase(DataFileImporterRepositoryInterface<Result<IEnumerable<TEntity>>> db)
    {
        this.db = db;
    }

    public Result<IEnumerable<TEntity>> Invoke()
    {
        return db.GetAll();
    }
}