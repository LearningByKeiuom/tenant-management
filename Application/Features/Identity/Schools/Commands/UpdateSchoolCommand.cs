using Application.Pipelines;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Schools.Commands;

public class UpdateSchoolCommand : IRequest<IResponseWrapper>, IValidateMe
{
    public UpdateSchoolRequest UpdateSchool { get; set; }
}