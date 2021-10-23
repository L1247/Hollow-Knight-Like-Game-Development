#region

using DDDCore;
using DDDCore.Usecase;
using Main.Entity;
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
        public void Should_Succeed_When_CreateStat()
        {
            var repository        = Substitute.For<IRepository<Main.Entity.Stat>>();
            var domainEventBus    = Substitute.For<IDomainEventBus>();
            var createStatUseCase = new CreateStatUseCase(domainEventBus , repository);
            var input             = new CreateStatInput();
            var statId            = GetGuid();
            var stat = StatBuilder
                       .NewInstance()
                       .SetStatId(statId)
                       .Build();
            repository.FindById(statId).Returns(stat);

            input.StatId = statId;
            createStatUseCase.Execute(input);
        }

    #endregion
    }
}