using Application.Wrappers;
using Mapster;
using MediatR;

namespace Application.Features.Identity.Schools.Queries;

public class GetSchoolByIdQuery : IRequest<IResponseWrapper>
{
    public int SchoolId { get; set; }
}