namespace Core.Models;

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? Detail { get; set; }
    public T? Data { get; set; }

    public bool isHasData()
    {
        return Success && null != Data;
    }

    public void CopyExceptData(Result<T> source)
    {
        Success = source.Success;
        Message = source.Message;
        Detail = source.Detail;
    }
}