using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Commands;

public class ChangeUserPasswordCommand : IRequest<IResponseWrapper>
{
    public ChangePasswordRequest ChangePassword { get; set; }
}