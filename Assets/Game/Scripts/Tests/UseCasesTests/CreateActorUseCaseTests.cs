using Main.ScriptableObjects;
using Main.UseCases.Actor.Create;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NSubstitute;
using NUnit.Framework;

public class CreateActorUseCaseTests : DDDUnitTestFixture
{
#region Test Methods

    [Test]
    public void Should_Succeed_When_Create_Actor()
    {
        var actorId       = "1234";
        var actorDataId   = "Pokemon";
        var iSoRepository = Substitute.For<iDataRepository>();
        var health    = 123;
        var actorDomainData = new ActorDomainData(){Health =  health};
        iSoRepository.GetActorDomainData(actorDataId).Returns(actorDomainData);

        var actorRepository    = new ActorRepository();
        var createActorUseCase = new CreateActorUseCase(domainEventBus , actorRepository , iSoRepository);
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