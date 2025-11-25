using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Commands;

public class CreateUserCommand : IRequest<IResponseWrapper>
{
    public CreateUserRequest CreateUser { get; set; }
}