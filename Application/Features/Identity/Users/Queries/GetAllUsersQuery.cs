using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Queries;

public class GetAllUsersQuery : IRequest<IResponseWrapper>
{
}