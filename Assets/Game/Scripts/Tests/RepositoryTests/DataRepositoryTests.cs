#region

using System;
using Main.DomainData;
using Main.GameDataStructure;
using NSubstitute;
using NUnit.Framework;
using Zenject;

#endregion

namespace Tests.RepositoryTests
{
    public class DataRepositoryTests : ZenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void Should_Success_When_GetActorDomainData()
        {
            // Arrange
            var actorDataId       = Guid.NewGuid().ToString();
            var actorDataOverView = Substitute.For<IActorDataOverView>();
            var actorData         = Substitute.For<IActorData>();
            actorDataOverView.FindActorData(actorDataId).Returns(actorData);
            Container.BindInstance(actorDataOverView).AsSingle();
            Container.Bind<DataRepository>().AsSingle();
            var dataRepository = Container.Resolve<DataRepository>();
            // Act
            var actorDomainData = dataRepository.GetActorData(actorDataId);
            // Assert
            Assert.NotNull(actorDomainData);
        }

    #endregion
    }
}