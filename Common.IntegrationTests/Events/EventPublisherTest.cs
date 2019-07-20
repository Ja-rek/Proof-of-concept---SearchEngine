using NUnit.Framework;
using Aveneo.Common.Domain.Events;
using Common.IntegrationTest.Domain.Events.Sut;
using System;

namespace Common.IntegrationTest.Domain.Events 
{
    public class Tests
    {
        [Test]
        public void Publish_WhenPublishEvent_ThenHandlerCanReciveEvent()
        {
            var publiser = ServiceLocator.Resolve<EventPublisher>();

            publiser.Publish(new EventStub());

            Assert.True(EventHandlerMock.EvetnHasRecived);
        }
    }
}
