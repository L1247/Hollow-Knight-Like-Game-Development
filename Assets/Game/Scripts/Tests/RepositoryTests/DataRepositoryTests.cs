using System;
using System.Collections.Generic;
using Main.GameDataStructure;
using Main.UseCases.Repository;
using NUnit.Framework;
using Zenject;

namespace Tests.RepositoryTests
{
    public class DataRepositoryTests : ZenjectUnitTestFixture
    {
        [Test]
        public void Should_Success_When_GetActorDomainData()
        {
            // Arrange
            var actorDataOverView = new ActorDataOverView();
            var actorData         = new ActorData(){ActorDomainData = new ActorDomainData()};
            var actorDataId       = Guid.NewGuid().ToString();
            actorData.ActorDataId = actorDataId;
            var actorDatas = new List<ActorData>(){actorData};
            actorDataOverView.ActorDatas = actorDatas;
            Container.BindInstance(actorDataOverView).AsSingle();
            Container.Bind<DataRepository>().AsSingle();
            var dataRepository  = Container.Resolve<DataRepository>();
            // Act
            var actorDomainData = dataRepository.GetActorDomainData(actorDataId);
            // Assert
            Assert.NotNull( actorDomainData );
        }
    }
}