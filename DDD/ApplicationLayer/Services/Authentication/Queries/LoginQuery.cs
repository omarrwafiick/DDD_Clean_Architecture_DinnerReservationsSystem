 
using ApplicationLayer.Services.Authentication.Common;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Authentication.Queries
{
    public record LoginQuery(string Email, string Password) : IRequest<Result<AuthResult>>;
}
