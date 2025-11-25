using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Commands;

public class DeleteUserCommand : IRequest<IResponseWrapper>
{
    public string UserId { get; set; }
}