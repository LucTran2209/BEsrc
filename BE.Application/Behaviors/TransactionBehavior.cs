using BE.Domain.Abstractions.UnitOfWork;
using BE.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BE.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> logger;
        private readonly ApplicationDbContext context;

        public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger, ApplicationDbContext dbContext)
        {
            this.logger = logger;
            this.context = dbContext;
           // this.unitOfWork = unitOfWork; 
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //if (this.context.GetCurrentTransaction() != null)
            //{
            //    return await next();
            //}

            //var strategy = this.context.Database.CreateExecutionStrategy();

            //return await strategy.ExecuteAsync(async () =>
            //{
            //    await this.dbContext.BeginTransactionAsync();
            //    var response = await next();
            //    await this.dbContext.CommitTransactionAsync();
            //    return response;
            //});

            return await next();
        }
    }
}
