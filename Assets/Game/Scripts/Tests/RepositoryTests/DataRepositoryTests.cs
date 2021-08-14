#region

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
            // // Arrange
            // var actorDataOverView = new ActorDataOverView();
            // var actorData         = new ActorData(){ActorDomainData = new ActorDomainData()};
            // var actorDataId       = Guid.NewGuid().ToString();
            // actorData.ActorDataId = actorDataId;
            // var actorDatas = new List<ActorData>(){actorData};
            // actorDataOverView.ActorDatas = actorDatas;
            // Container.BindInstance(actorDataOverView).AsSingle();
            // Container.Bind<DataRepository>().AsSingle();
            // var dataRepository  = Container.Resolve<DataRepository>();
            // // Act
            // var actorDomainData = dataRepository.GetActorDomainData(actorDataId);
            // // Assert
            // Assert.NotNull( actorDomainData );
        }

    #endregion
    }
}