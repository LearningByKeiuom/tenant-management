using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Commands;

public class ActivateTenantCommand : IRequest<IResponseWrapper>
{
    public string TenantId { get; set; }
}