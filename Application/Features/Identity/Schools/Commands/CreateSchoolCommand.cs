using Application.Pipelines;
using Application.Wrappers;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Identity.Schools.Commands;

public class CreateSchoolCommand : IRequest<IResponseWrapper>, IValidateMe
{
    public CreateSchoolRequest CreateSchool { get; set; }
}