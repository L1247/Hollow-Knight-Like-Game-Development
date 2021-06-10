using DDDCore.Model;
using Zenject;

namespace MainTests.ExtenjectTestFramwork
{
    public class DDDUnitTestFixture : ExntenjectUnitTestFixture
    {
    #region Protected Variables

        protected DomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<DomainEvent>();
            Container.Bind<DomainEventBus>().AsSingle();
            domainEventBus = Container.Resolve<DomainEventBus>();
        }

    #endregion
    }
}