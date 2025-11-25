using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Roles.Commands;

public class DeleteRoleCommand : IRequest<IResponseWrapper>
{
    public string RoleId { get; set; }
}