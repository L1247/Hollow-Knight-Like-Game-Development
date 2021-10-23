#region

using DDDCore;
using DDDCore.Model;
using NSubstitute;
using Zenject;

#endregion

namespace MainTests.ExtenjectTestFramwork
{
    public class DDDUnitTestFixture : ExntenjectUnitTestFixture
    {
    #region Protected Variables

        protected IDomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<DomainEvent>();
            domainEventBus = Substitute.For<IDomainEventBus>();
        }

    #endregion
    }
}