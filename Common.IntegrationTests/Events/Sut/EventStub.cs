using Aveneo.Common.Domain.Events;

namespace Common.IntegrationTest.Domain.Events.Sut
{
    internal class EventStub : IEvent
    {
        public EventStub()
        {
            Id = 5;
        }

        public int Id { get; }
    }
}
