using FluentResults;
using FluentValidation;
using MediatR;
 
namespace ApplicationLayer.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }
         
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return (dynamic)Result.Fail<TResponse>(errors);
        }
    }
}
