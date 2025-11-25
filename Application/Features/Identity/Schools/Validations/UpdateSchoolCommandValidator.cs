using Application.Features.Schools.Commands;
using FluentValidation;

namespace Application.Features.Identity.Schools.Validations;

public class UpdateSchoolCommandValidator : AbstractValidator<UpdateSchoolCommand>
{
    public UpdateSchoolCommandValidator(ISchoolService schoolService)
    {
        RuleFor(command => command.UpdateSchool)
            .SetValidator(new UpdateSchoolRequestValidator(schoolService));
    }
}