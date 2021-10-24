#region

using DDDCore;
using Main.Entity;
using Main.UseCases.Stat;
using MainTests.ExtenjectTestFramework;
using NSubstitute;
using NUnit.Framework;

#endregion

namespace UseCasesTests.Stat
{
    public class ModifyAmountUseCaseTest : SimpleTest
    {
    #region Test Methods

        [Test]
        public void ModifyAmount()
        {
            var actorId             = GetGuid();
            var statName            = GetGuid();
            var statAmount          = 100;
            var amount              = -15;
            var repository          = Substitute.For<IStatRepository>();
            var domainEventBus      = Substitute.For<IDomainEventBus>();
            var modifyAmountUseCase = new ModifyAmountUseCase(domainEventBus , repository);
            var input               = new ModifyAmountInput();
            var stat = StatBuilder
                       .NewInstance()
                       .SetActorId(actorId)
                       .SetStatName(statName)
                       .SetAmount(statAmount)
                       .Build();

            repository.FindStat(actorId , statName).Returns(stat);

            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
            modifyAmountUseCase.Execute(input);

            // assertion
            // 100 + -15 = 85
            Assert.AreEqual(statAmount + amount , stat.Amount , "stat amount is not equal");

            domainEventBus.Received(1).PostAll(stat);
        }

        [Test]
        public void ModifyAmount_When_Amount_Is_Greater_Than_Stat_Amount()
        {
            var actorId             = GetGuid();
            var statName            = GetGuid();
            var statAmount          = 100;
            var amount              = -150;
            var repository          = Substitute.For<IStatRepository>();
            var domainEventBus      = Substitute.For<IDomainEventBus>();
            var modifyAmountUseCase = new ModifyAmountUseCase(domainEventBus , repository);
            var input               = new ModifyAmountInput();
            var stat = StatBuilder
                       .NewInstance()
                       .SetActorId(actorId)
                       .SetStatName(statName)
                       .SetAmount(statAmount)
                       .Build();

            repository.FindStat(actorId , statName).Returns(stat);

            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
            modifyAmountUseCase.Execute(input);

            // assertion
            // 100 + -150 = 0
            Assert.AreEqual(0 , stat.Amount , "stat amount is not equal");

            domainEventBus.Received(1).PostAll(stat);
        }

    #endregion
    }
}