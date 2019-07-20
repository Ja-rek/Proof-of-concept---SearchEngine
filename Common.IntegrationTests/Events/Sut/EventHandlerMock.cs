using System;
using Aveneo.Common.Domain.Events;

namespace Common.IntegrationTest.Domain.Events.Sut
 
{
    internal class EventHandlerMock: IHandleEvent<EventStub>
    {
        public void Handle(EventStub @event)
        {
             EvetnHasRecived = @event.Id == 5;
        }

        public static bool EvetnHasRecived { get; private set; }
    }
}
