using Main.Actor;
using NUnit.Framework;

namespace MainTests.ActorTests
{
    public class CreateActorUseCaseTests
    {
        [Test]
        public void Should_Succeed_When_Create_Actor()
        {
            var actor = new Actor("1234" , "Pokemon");

            Assert.NotNull( actor.ActorId );
            Assert.AreEqual( "1234" , actor.ActorId );
            Assert.NotNull( actor.ActorDataId );
            Assert.AreEqual( "Pokemon" , actor.ActorDataId );
        }
    }
}