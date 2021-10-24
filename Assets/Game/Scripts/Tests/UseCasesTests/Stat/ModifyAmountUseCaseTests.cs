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
    #region Private Variables

        private string              actorId;
        private string              statName;
        private IStatRepository     repository;
        private IDomainEventBus     domainEventBus;
        private ModifyAmountUseCase modifyAmountUseCase;
        private ModifyAmountInput   input;
        private Main.Entity.Stat    stat;
        private int                 amount;
        private int                 statAmount;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void SetUp()
        {
            actorId             = GetGuid();
            statName            = GetGuid();
            repository          = Substitute.For<IStatRepository>();
            domainEventBus      = Substitute.For<IDomainEventBus>();
            modifyAmountUseCase = new ModifyAmountUseCase(domainEventBus , repository);
            input               = new ModifyAmountInput();
        }

    #endregion

    #region Test Methods

        [Test]
        public void ModifyAmount()
        {
            amount     = -15;
            statAmount = 100;
            CreateStat();
            CreateInput();

            modifyAmountUseCase.Execute(input);

            // assertion
            // 100 + -15 = 85
            AssetStatAmount(85);

            AssetEventPostAll();
        }

        [Test]
        public void ModifyAmount_When_Amount_Is_Greater_Than_Stat_Amount()
        {
            amount     = -150;
            statAmount = 100;
            CreateStat();
            CreateInput();

            modifyAmountUseCase.Execute(input);

            // assertion
            // 100 + -150 = 0
            AssetStatAmount(0);

            AssetEventPostAll();
        }

    #endregion

    #region Private Methods

        private void AssetEventPostAll()
        {
            domainEventBus.Received(1).PostAll(stat);
        }

        private void AssetStatAmount(int expectedAmount)
        {
            Assert.AreEqual(expectedAmount , stat.Amount , "stat amount is not equal");
        }

        private void CreateInput()
        {
            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
        }

        private void CreateStat()
        {
            stat = StatBuilder
                   .NewInstance()
                   .SetActorId(actorId)
                   .SetStatName(statName)
                   .SetAmount(statAmount)
                   .Build();

            repository.FindStat(actorId , statName).Returns(stat);
        }

    #endregion
    }
}