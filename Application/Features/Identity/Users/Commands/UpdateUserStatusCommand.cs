using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Commands;

public class UpdateUserStatusCommand : IRequest<IResponseWrapper>
{
    public ChangeUserStatusRequest ChangeUserStatus { get; set; }
}