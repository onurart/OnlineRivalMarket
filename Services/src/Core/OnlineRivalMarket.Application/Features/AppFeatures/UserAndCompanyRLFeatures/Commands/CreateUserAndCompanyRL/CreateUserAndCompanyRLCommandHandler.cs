﻿namespace OnlineRivalMarket.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
public sealed class CreateUserAndCompanyRLCommandHandler : ICommandHandler<CreateUserAndCompanyRLCommand, CreateUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _userAndCompanyRelationshipService;
    public CreateUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService userAndCompanyRelationshipService)
    {
        _userAndCompanyRelationshipService = userAndCompanyRelationshipService;
    }
    public async Task<CreateUserAndCompanyRLCommandResponse> Handle(CreateUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationship entity = await _userAndCompanyRelationshipService.GetByUserIdAndCompanyId(request.AppUserId, request.CompanyId, cancellationToken);
        if (entity != null) throw new Exception("Bu kullanıcı daha önce bu şirkete kayıt edilmiş!");

        UserAndCompanyRelationship userAndCompanyRelationship = new(
            Guid.NewGuid().ToString(),
            request.AppUserId,
            request.CompanyId);

        await _userAndCompanyRelationshipService.CreateAsync(userAndCompanyRelationship, cancellationToken);
        return new();
    }
}