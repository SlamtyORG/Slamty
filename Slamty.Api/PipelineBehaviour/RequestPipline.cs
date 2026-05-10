using FluentValidation;
using MediatR;

namespace Slamty.API.PipelineBehaviour
{
    public class RequestPipline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestPipline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(o => o.Validate(context))
                                      .SelectMany(o => o.Errors)
                                      .Where(o => o is not null);

            if (failures.Any())
                throw new ValidationException(failures);

            return next();

        }
    }
}
