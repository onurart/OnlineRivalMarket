﻿namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword;
public sealed record ChangePasswordCommand(string email, string currentPassword, string newPassword) : ICommand<ChangePasswordCommandResponse>;
