using System;
using Entity.Builder;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NUnit.Framework;

public class ChangeDirectionUseCaseTest : DDDUnitTestFixture
{
#region Test Methods

    [Test]
    public void Should_Succeed_When_ChangeDirection()
    {
        var actorRepository        = new ActorRepository();
        var changeDirectionUseCase = new ChangeDirectionUseCase(_domainEventBus , actorRepository);
        var input                  = new ChangeDirectionInput();

        var actorId   = Guid.NewGuid().ToString();
        var direction = 1218738907;
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .Build();

        actorRepository.Save(actor);

        input.ActorId   = actorId;
        input.Direction = direction;
        changeDirectionUseCase.Execute(input);

        var actorById = actorRepository.FindById(actorId);
        Assert.NotNull(actorById);
        Assert.AreEqual(direction , actor.Direction);
    }

#endregion
}