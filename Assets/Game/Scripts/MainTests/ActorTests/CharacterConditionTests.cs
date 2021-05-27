using Main.ViewComponent;
using NUnit.Framework;

namespace MainTests.ActorTests
{
    public class CharacterConditionTests
    {
    #region Test Methods

        [Test]
        public void Should_Return_True_When_Get_CanMoving()
        {
            var characterCondition = new CharacterCondition();
            var canMoving          = characterCondition.CanMoving();
            Assert.AreEqual(true , canMoving);
        }

        [Test]
        public void Should_Return_False_When_IsMoving_False()
        {
            var characterCondition = new CharacterCondition();
            var canMoving          = characterCondition.CanMoving();
            Assert.AreEqual(false , canMoving);
        }

    #endregion
    }
}