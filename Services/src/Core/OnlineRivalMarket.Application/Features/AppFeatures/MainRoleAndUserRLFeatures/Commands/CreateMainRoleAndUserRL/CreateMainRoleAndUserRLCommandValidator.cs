﻿namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
public sealed class CreateMainRoleAndUserRLCommandValidator : AbstractValidator<CreateMainRoleAndUserRLCommand>
{
    public CreateMainRoleAndUserRLCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı seçmelisiniz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı seçmelisiniz!");
        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Rol seçmelisiniz!");
        RuleFor(p => p.MainRoleId).NotNull().WithMessage("Rol seçmelisiniz!");
    }
}