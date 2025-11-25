using Application.Wrappers;
using Mapster;
using MediatR;

namespace Application.Features.Identity.Schools.Queries;

public class GetSchoolByNameQuery : IRequest<IResponseWrapper>
{
    public string Name { get; set; }
}