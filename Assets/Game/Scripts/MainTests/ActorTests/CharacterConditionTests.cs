#region

using Main.ViewComponent;
using NUnit.Framework;

#endregion

namespace MainTests.ActorTests
{
    public class CharacterConditionTests
    {
    #region Private Variables

        private CharacterCondition characterCondition;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void SetUp()
        {
            characterCondition = new CharacterCondition();
        }

    #endregion

    #region Test Methods

        [Test]
        public void Should_Return_True_When_Get_CanMoving()
        {
            Should_CanMoving_Response(true);
        }

        [Test]
        public void Should_Return_False_When_IsMoving_False()
        {
            Should_CanMoving_Response(false);
        }

    #endregion

    #region Private Methods

        private void Should_CanMoving_Response(bool expectedCanMoving)
        {
            var canMoving = characterCondition.CanMoving();
            Assert.AreEqual(expectedCanMoving , canMoving);
        }

    #endregion
    }
}