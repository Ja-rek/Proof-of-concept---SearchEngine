namespace Aveneo.Common.Domain.Events
{
    public interface IHandleEvent<TEvent> : IHandler
    {
        void Handle(TEvent @event);
    }
}
