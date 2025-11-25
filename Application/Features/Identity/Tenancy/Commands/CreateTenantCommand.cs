using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Commands;

public class CreateTenantCommand : IRequest<IResponseWrapper>
{
    public CreateTenantRequest CreateTenant { get; set; }
}