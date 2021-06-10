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
        var iSoRepository = Substitute.For<iSoRepository>();
        // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
        var health    = 123;
        var actorData = new ActorData { Health = health };
        iSoRepository.GetActorData(actorDataId).Returns(actorData);

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
    }

#endregion
}