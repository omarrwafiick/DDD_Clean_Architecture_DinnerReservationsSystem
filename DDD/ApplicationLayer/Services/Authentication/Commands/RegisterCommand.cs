

using ApplicationLayer.Services.Authentication.Common;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Authentication.Commands
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<Result<AuthResult>>;
}
