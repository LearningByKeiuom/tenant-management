using Application.Wrappers;
using Mapster;
using MediatR;

namespace Application.Features.Identity.Schools.Queries;

public class GetSchoolsQuery : IRequest<IResponseWrapper>
{
}