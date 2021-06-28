using Main.Decoupling;
using NUnit.Framework;

namespace Tests.DecouplingTests
{
    public class DataBaseServiceTests
    {
    #region Test Methods

        [Test]
        [TestCase(1 , 100 , 10)]
        [TestCase(2 , 200 , 50)]
        public void Should_Get_Correct_ActorData(int actorDataId , int expectedHp , int expectedAtk)
        {
            var dataBaseService = new DataBaseService(new DataBaseServer());
            var actorData       = dataBaseService.GetActorData(actorDataId);
            Assert.NotNull(actorData);
            Assert.AreEqual(expectedHp ,  actorData.Hp);
            Assert.AreEqual(expectedAtk , actorData.Atk);
        }

        [Test]
        public void Should_Get_Null_ActorData()
        {
            var dataBaseService = new DataBaseService(new DataBaseServer());
            var actorData       = dataBaseService.GetActorData(3);
            Assert.Null(actorData);
        }

    #endregion
    }
}