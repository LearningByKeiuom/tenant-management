using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Queries;

public class GetTenantsQuery : IRequest<IResponseWrapper>
{
}