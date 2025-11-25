using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Queries;

public class GetTenantByIdQuery : IRequest<IResponseWrapper>
{
    public string TenantId { get; set; }
}