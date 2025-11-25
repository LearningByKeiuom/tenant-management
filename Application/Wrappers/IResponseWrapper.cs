namespace Application.Wrappers;

public interface IResponseWrapper
{
    List<string> Messages { get; set; }
    bool IsSuccessful { get; set; }
}