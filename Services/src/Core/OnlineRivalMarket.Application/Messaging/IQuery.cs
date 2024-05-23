namespace OnlineRivalMarket.Application.Messaging;
public interface IQuery<out TResponse> : IRequest<TResponse> { }
