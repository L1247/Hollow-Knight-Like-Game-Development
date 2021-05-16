using Main.Entity.Model;
using Main.Entity.Model.Events;
using NUnit.Framework;

namespace MainTests.ActorTests
{
    public class ActorTests
    {
    #region Test Methods

        [Test]
        public void Should_Publish_Actor_Created_When_Create_Actor()
        {
            var actorId     = "1234";
            var actorDataId = "Pokemon";
            var actor = ActorBuilder.NewInstance()
                                    .SetActorId(actorId)
                                    .SetActorDataId(actorDataId)
                                    .Build();
            var domainEvents = actor.GetDomainEvents();
            Assert.AreEqual(1 , domainEvents.Count);
            var actorCreated = domainEvents[0] as ActorCreated;
            Assert.AreEqual(actorId ,     actorCreated.ActorId);
            Assert.AreEqual(actorDataId , actorCreated.ActorDataId);
            Assert.AreEqual(1 ,           actorCreated.Direction);
        }

    #endregion
    }
}