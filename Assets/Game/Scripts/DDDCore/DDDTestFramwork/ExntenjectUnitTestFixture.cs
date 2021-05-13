using NUnit.Framework;
using Zenject;

namespace MainTests.ExtenjectTestFramwork
{
    public abstract class ExntenjectUnitTestFixture
    {
    #region Protected Variables

        protected DiContainer Container { get; private set; }

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public virtual void Setup()
        {
            Container = new DiContainer(StaticContext.Container);
        }

        [TearDown]
        public virtual void Teardown()
        {
            StaticContext.Clear();
        }

    #endregion
    }
}