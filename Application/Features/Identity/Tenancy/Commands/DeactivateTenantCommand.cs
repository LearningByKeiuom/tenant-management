using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Commands;

public class DeactivateTenantCommand : IRequest<IResponseWrapper>
{
    public string TenantId { get; set; }
}