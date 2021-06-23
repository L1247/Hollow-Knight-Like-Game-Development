using Entity.Builder;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NUnit.Framework;

public class MakeActorDieUseCaseTest : DDDUnitTestFixture
{
#region Test Methods

    [Test]
    public void Should_Succeed_When_MakeActorDie()
    {
        var actorRepository     = new ActorRepository();
        var makeActorDieUseCase = new MakeActorDieUseCase(domainEventBus , actorRepository);
        var input               = new MakeActorDieInput();

        var actorId = "1234";
        var newActor = ActorBuilder.NewInstance()
                                   .SetActorId(actorId)
                                   .Build();
        actorRepository.Save(newActor);
        var actor = actorRepository.FindById(actorId);
        Assert.NotNull(actor);

        input.ActorId = actorId;
        Assert.AreEqual(false , actor.IsDead);
        makeActorDieUseCase.Execute(input);

        Assert.AreEqual(true , actor.IsDead , "actor IsDead false");
    }

#endregion
}