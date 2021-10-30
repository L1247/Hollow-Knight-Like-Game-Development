#region

using Main.DomainData;
using Main.UseCases.Actor.Create;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NSubstitute;
using NUnit.Framework;

#endregion

namespace UseCasesTests.Actor
{
    public class CreateActorUseCaseTests : DDDUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void Should_Succeed_When_Create_Actor()
        {
            var actorId        = "1234";
            var actorDataId    = "Pokemon";
            var dataRepository = Substitute.For<IDataRepository>();
            var health         = 123;
            var actorData      = Substitute.For<IActorData>();
            actorData.Health.Returns(health);
            dataRepository.GetActorData(actorDataId).Returns(actorData);

            var actorRepository    = new ActorRepository();
            var createActorUseCase = new CreateActorUseCase(domainEventBus , actorRepository , dataRepository);
            var input              = new CreateActorInput();
            input.ActorId     = actorId;
            input.ActorDataId = actorDataId;
            createActorUseCase.Execute(input);

            var actor = actorRepository.FindById(actorId);
            Assert.NotNull(actor);
            Assert.NotNull(actor.GetId());
            Assert.AreEqual(actorId , actor.GetId());
            Assert.NotNull(actor.ActorDataId);
            Assert.AreEqual(actorDataId , actor.ActorDataId);
            // 角色預設面右
            Assert.AreEqual(1 ,      actor.Direction);
            Assert.AreEqual(health , actor.Health);
            Assert.AreEqual(false ,  actor.IsDead);
        }

    #endregion
    }
}