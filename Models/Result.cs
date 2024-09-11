namespace Core.Models;

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public bool isHasData() {
        return Success && null != Data;
    }
}