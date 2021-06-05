using Main.UseCases.Actor.Create;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NUnit.Framework;

public class CreateActorUseCaseTests : DDDUnitTestFixture
{
#region Test Methods

    [Test]
    public void Should_Succeed_When_Create_Actor()
    {
        var actorId            = "1234";
        var actorDataId        = "Pokemon";
        var actorRepository    = new ActorRepository();
        var createActorUseCase = new CreateActorUseCase(_domainEventBus , actorRepository);
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
        Assert.AreEqual(1 , actor.Direction);
    }

#endregion
}