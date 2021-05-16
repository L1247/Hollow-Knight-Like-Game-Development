using Main.Actor.Events;
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

        [Test]
        public void Should_Publish_Direction_Changed_When_Change_Direction()
        {
            var actorId   = "1234";
            var direction = 123789127;
            var actor = ActorBuilder.NewInstance()
                                    .SetActorId(actorId)
                                    .Build();
            actor.ChangeDirection(direction);
            var domainEvents = actor.GetDomainEvents();
            Assert.AreEqual(2 , domainEvents.Count);
            var directionChanged = domainEvents[1] as DirectionChanged;
            Assert.AreEqual(actorId ,   directionChanged.ActorId);
            Assert.AreEqual(direction , directionChanged.Direction);
        }

    #endregion
    }
}