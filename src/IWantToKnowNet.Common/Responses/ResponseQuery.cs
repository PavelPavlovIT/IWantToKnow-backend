namespace IWantToKnowNet.Common.Responses;

public class ResponseQuery<T>(bool success, string message = "", IList<T>? items = null) where T : class
{
    public IList<T>? Items => items;
    public int Count => Items == null ? 0 : items!.Count();
    public bool Success => success;
    public string Message => message;
}