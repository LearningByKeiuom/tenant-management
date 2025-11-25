namespace Application.Features.Identity.Schools;

public class CreateSchoolRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime EstablishedDate { get; set; }
}