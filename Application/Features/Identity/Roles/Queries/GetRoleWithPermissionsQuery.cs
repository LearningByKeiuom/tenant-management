using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Roles.Queries;

public class GetRoleWithPermissionsQuery : IRequest<IResponseWrapper>
{
    public string RoleId { get; set; }
}