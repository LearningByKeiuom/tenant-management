using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Schools.Commands;

public class DeleteSchoolCommand : IRequest<IResponseWrapper>
{
    public int SchoolId { get; set; }
}