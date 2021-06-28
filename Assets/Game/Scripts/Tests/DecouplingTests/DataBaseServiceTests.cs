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
        public void Should_Create_Actor(int actorDataId , int expectedHp , int expectedAtk)
        {
            var dataBaseService = new FakeDataBaseService();
            var actorSpawner    = new ActorSpawner(dataBaseService);
            var actor           = actorSpawner.Spawn(actorDataId);
            Assert.NotNull(actor);
            Assert.AreEqual(expectedHp ,  actor.Hp);
            Assert.AreEqual(expectedAtk , actor.Atk);
        }

        [Test]
        public void should_Return_Null_With_out_of_Range_Number()
        {
            var dataBaseService = new FakeDataBaseService();
            var actorSpawner    = new ActorSpawner(dataBaseService);
            var actor           = actorSpawner.Spawn(3);
            Assert.Null(actor);
        }

    #endregion
    }
}