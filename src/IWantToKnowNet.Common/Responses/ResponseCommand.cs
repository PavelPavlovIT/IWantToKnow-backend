namespace IWantToKnowNet.Common.Responses;

public class ResponseCommand(bool success, string message = "", object? result = null)
{
    public bool Success => success;
    public string Message => message;
    public object? Result => result;
}