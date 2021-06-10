using System;
using Entity.Builder;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using MainTests.ExtenjectTestFramwork;
using NUnit.Framework;

public class DealDamageUseCaseTest : DDDUnitTestFixture
{
#region Test Methods

    [Test]
    public void Should_Succeed_When_DealDamage()
    {
        var actorRepository   = new ActorRepository();
        var dealDamageUseCase = new DealDamageUseCase(domainEventBus , actorRepository);
        var input             = new DealDamageInput();

        var actorId = Guid.NewGuid().ToString();
        var newActor = ActorBuilder.NewInstance()
                                   .SetActorId(actorId)
                                   .Build();
        actorRepository.Save(newActor);

        input.ActorId = actorId;
        dealDamageUseCase.Execute(input);

        var actor = actorRepository.FindById(actorId);
        Assert.NotNull(actor);
    }

#endregion
}