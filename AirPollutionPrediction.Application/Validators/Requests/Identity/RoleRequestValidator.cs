using AirPollutionPrediction.Application.Requests.Identity;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace AirPollutionPrediction.Application.Validators.Requests.Identity
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator(IStringLocalizer<RoleRequestValidator> localizer)
        {
            _ = RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Name is required"]);
        }
    }
}
