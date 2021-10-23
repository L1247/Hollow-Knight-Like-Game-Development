#region

using DDDCore;
using DDDCore.Usecase;
using Main.UseCases.Stat;
using MainTests.ExtenjectTestFramework;
using NSubstitute;
using NUnit.Framework;

#endregion

namespace UseCasesTests.Stat
{
    public class CreateStatUseCaseTest : SimpleTest
    {
    #region Test Methods

        [Test]
        public void CreateStat()
        {
            var statName = "123";
            var amount   = 999;
            var actorId  = GetGuid();

            var                           domainEventBus    = Substitute.For<IDomainEventBus>();
            IRepository<Main.Entity.Stat> repository        = new StatRepository();
            var                           createStatUseCase = new CreateStatUseCase(domainEventBus , repository);
            var                           input             = new CreateStatInput();

            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
            createStatUseCase.Execute(input);

            var stats = repository.FindAll();
            Assert.AreEqual(1 , stats.Count , "stats.count is not equal");
            var stat = stats[0];
            // assert properties
            Assert.NotNull(stat.GetId() , "stat.GetId() is null");
            Assert.AreEqual(statName , stat.Name ,    "Name is not equal");
            Assert.AreEqual(amount ,   stat.Amount ,  "Amount is not equal");
            Assert.AreEqual(actorId ,  stat.ActorId , "ActorId is not equal");
            // assert events
            domainEventBus.Received(1).PostAll(stat);
        }

    #endregion
    }
}