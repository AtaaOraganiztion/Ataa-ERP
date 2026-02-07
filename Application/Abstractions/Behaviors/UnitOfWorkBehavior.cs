using System.Transactions;
using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Abstractions.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!typeof(TRequest).IsAssignableTo(typeof(IBaseCommand)))
        {
            return await next(cancellationToken);
        }

        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        TResponse response = await next(cancellationToken);
        transactionScope.Complete();
        return response;
    }
}