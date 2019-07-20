namespace Aveneo.Common.Domain.Events
{
    public interface IHandleEvent<TEvent> : IHandler
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
