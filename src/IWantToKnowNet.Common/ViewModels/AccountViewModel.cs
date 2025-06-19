namespace IWantToKnowNet.Common.ViewModels;

public record AccountViewModel(string Id, string? Name, string? GivenName, string Lang, string ExpireDateTime, bool Expired);