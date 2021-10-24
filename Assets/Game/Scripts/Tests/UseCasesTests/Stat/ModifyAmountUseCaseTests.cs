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
        private IStat               stat;
        private ModifyAmountUseCase modifyAmountUseCase;
        private ModifyAmountInput   input;
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
            var expectedAmount = 85;
            AssetStatAmount(expectedAmount);
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
            var expectedAmount = 0;
            AssetStatAmount(expectedAmount);
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
            stat.Received(1).SetAmount(expectedAmount);
        }

        private void CreateInput()
        {
            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
        }

        private void CreateStat()
        {
            stat = Substitute.For<IStat>();
            stat.Amount.Returns(statAmount);

            repository.FindStat(actorId , statName).Returns(stat);
        }

    #endregion
    }
}