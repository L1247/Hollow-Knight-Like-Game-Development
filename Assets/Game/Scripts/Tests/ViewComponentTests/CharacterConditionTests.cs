#region

using Main.ViewComponent;
using NUnit.Framework;

#endregion

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
    [TestCase(true , false , false)]
    [TestCase(true , true ,  false)]
    public void Should_Return_True_When_Get_CanMoving_With_Arguments(
        bool isMoving , bool isAttacking , bool isOnGround)
    {
        characterCondition.IsMoving    = isMoving;
        characterCondition.IsAttacking = isAttacking;
        characterCondition.IsOnGround  = isOnGround;
        Should_CanMoving_Response(true);
    }

    [Test]
    [TestCase(false , false , false)]
    [TestCase(true ,  true ,  true)]
    public void Should_Return_False_When_Get_CanMoving_With_Arguments(
        bool isMoving , bool isAttacking , bool isOnGround)
    {
        characterCondition.IsMoving    = isMoving;
        characterCondition.IsAttacking = isAttacking;
        characterCondition.IsOnGround  = isOnGround;
        Should_CanMoving_Response(false);
    }

    [Test]
    [TestCase(true,false)]
    [TestCase(false , true)]
    public void Should_Return_False_With_IsDead(bool isDead , bool exceptedCanMoving)
    {
        characterCondition.IsDead   = isDead;
        characterCondition.IsMoving = true;
        Should_CanMoving_Response(exceptedCanMoving);
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