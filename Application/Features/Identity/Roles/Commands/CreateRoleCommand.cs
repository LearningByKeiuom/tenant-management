using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Roles.Commands;

public class CreateRoleCommand : IRequest<IResponseWrapper>
{
    public CreateRoleRequest CreateRole { get; set; }
}