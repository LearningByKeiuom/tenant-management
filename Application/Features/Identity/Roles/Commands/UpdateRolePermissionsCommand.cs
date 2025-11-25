using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Roles.Commands;

public class UpdateRolePermissionsCommand : IRequest<IResponseWrapper>
{
    public UpdateRolePermissionsRequest UpdateRolePermissions { get; set; }
}