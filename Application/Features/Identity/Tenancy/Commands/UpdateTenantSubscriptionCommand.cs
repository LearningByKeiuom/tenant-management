using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Tenancy.Commands;

public class UpdateTenantSubscriptionCommand : IRequest<IResponseWrapper>
{
    public UpdateTenantSubscriptionRequest UpdateTenantSubscription { get; set; }
}