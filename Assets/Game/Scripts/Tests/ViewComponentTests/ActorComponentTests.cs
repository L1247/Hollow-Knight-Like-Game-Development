using Main.ViewComponent;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ActorComponentTests
{
#region Private Variables

    private ActorComponent      actorComponent;
    private GameObject          gameObject;
    private ICharacterCondition characterCondition;
    private IUnityComponent     unityComponent;
    private Text                textComponent;
    private Transform           rendererTransform;

#endregion

#region Setup/Teardown Methods

    [SetUp]
    public void Setup()
    {
        gameObject                        = new GameObject();
        actorComponent                    = gameObject.AddComponent<ActorComponent>();
        textComponent                     = gameObject.AddComponent<Text>();
        rendererTransform                 = new GameObject("Renderer").transform;
        actorComponent.Renderer           = rendererTransform;
        unityComponent                    = Substitute.For<IUnityComponent>();
        actorComponent.unityComponent     = unityComponent;
        characterCondition                = Substitute.For<ICharacterCondition>();
        actorComponent.characterCondition = characterCondition;
        Assert.NotNull(actorComponent.unityComponent);
        Assert.NotNull(actorComponent.characterCondition);
    }

#endregion

#region Test Methods

    [Test]
    public void Should_Succeed_When_Call_SetText_ForIdAndDataId()
    {
        // arrange
        var displayText = "fdsjhjkfh";
        actorComponent.text_IdAndDataId = textComponent;
        // act
        actorComponent.SetText(displayText);
        // assert
        Assert.NotNull(actorComponent.text_IdAndDataId);
        Assert.AreEqual(displayText , actorComponent.text_IdAndDataId.text);
    }

    [Test]
    public void Should_Succeed_When_Call_SetText_ForHealth()
    {
        var health = 123;
        actorComponent.text_Health = textComponent;
        // arrange
        var displayText = $"Health:{health}";
        // act
        actorComponent.SetHealthText(health);
        // assert
        Assert.NotNull(actorComponent.text_Health);
        Assert.AreEqual(displayText , actorComponent.text_Health.text);
    }

    [Test]
    [TestCase(1 , -1)]
    [TestCase(0 , 1)]
    public void Should_Succeed_When_Call_SetDirection(int directionValue , int expectedScaleValue)
    {
        // act
        actorComponent.SetDirection(directionValue);
        // assert
        Assert.AreEqual(expectedScaleValue , rendererTransform.localScale.x);
    }

    [Test]
    public void Should_Is_Jumping_True_When_Call_Jump()
    {
        // arrange
        characterCondition.IsOnGround = true;
        Assert.AreEqual(true , characterCondition.IsOnGround);
        // act
        actorComponent.Jump();
        // assert
        Assert.AreEqual(false , characterCondition.IsOnGround);
    }

    [Test]
    public void Should_Call_PlayAnimation_Jump_When_Call_Jump()
    {
        // act
        actorComponent.Jump();
        // assert
        unityComponent.Received(1).PlayAnimation("Jump");
    }

    [Test]
    public void Should_Call_AddForce_When_Call_Jump()
    {
        // arrange
        var jumpForce = 10;
        actorComponent.JumpForce = jumpForce;
        // act
        actorComponent.Jump();
        // assert
        unityComponent.Received(1).AddForce(Vector2.up * jumpForce);
    }

    [Test]
    public void Should_Is_Attacking_True_When_Call_Attack()
    {
        // arrange
        Assert.AreEqual(false , characterCondition.IsAttacking);
        // act
        actorComponent.Attack();
        // assert
        Assert.AreEqual(true , characterCondition.IsAttacking);
    }

    [Test]
    public void Should_Is_Attacking_False_When_Call_OnAttackEnd()
    {
        // arrange
        characterCondition.IsAttacking = true;
        Assert.AreEqual(true , characterCondition.IsAttacking);
        // act
        actorComponent.OnAttackEnd();
        // assert
        Assert.AreEqual(false , characterCondition.IsAttacking);
    }

    [Test]
    public void Should_Call_PlayAnimation_Attack_When_Call_Attack()
    {
        // act
        actorComponent.Attack();
        // assert
        unityComponent.Received(1).PlayAnimation("Attack" , actorComponent.OnAttackEnd);
    }

    [Test]
    public void Should_Call_PlayAnimation_Die_When_Call_MakeDie()
    {
        // act
        actorComponent.MakeDie();
        // assert
        unityComponent.Received(1).PlayAnimation("Die");
    }

    [Test]
    public void Should_Hide_Id_Health_Text_When_Call_MakeDie()
    {
        // arrange
        var textComponentForHealth = new GameObject().AddComponent<Text>();
        Assert.NotNull(textComponentForHealth);
        actorComponent.text_IdAndDataId = textComponent;
        actorComponent.text_Health      = textComponentForHealth;
        Assert.NotNull(actorComponent.text_Health);
        Assert.NotNull(actorComponent.text_IdAndDataId);
        Assert.AreEqual(true , textComponent.enabled);
        Assert.AreEqual(true , textComponentForHealth.enabled);
        // act
        actorComponent.MakeDie();
        // assert
        Assert.AreEqual(false , textComponent.enabled);
        Assert.AreEqual(false , textComponentForHealth.enabled);
    }


    [Test]
    public void Should_Call_MoveCharacter_When_Call_MoveCharacter()
    {
        // act
        actorComponent.MoveCharacter();
        // assert
        ShouldCallMoveCharacter();
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Should_Call_MoveCharacter_When_CanMoving_Set_Value(bool canMoving)
    {
        characterCondition.CanMoving().Returns(canMoving);
        // act
        actorComponent.Update();
        // assert
        if (canMoving) ShouldCallMoveCharacter();
        if (canMoving == false) ShouldNotCallMoveCharacter();
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Should_Set_Condition_IsOnGround_When_Call_UnityComponent_IsGrounding(bool exceptIsOnGround)
    {
        characterCondition.IsOnGround = !exceptIsOnGround;
        unityComponent.IsGrounding().Returns(exceptIsOnGround);
        actorComponent.Update();
        Assert.AreEqual(exceptIsOnGround , characterCondition.IsOnGround);
    }

#endregion

#region Private Methods

    private void ShouldCallMoveCharacter()
    {
        var movement = actorComponent.GetMovement();
        unityComponent.Received(1).MoveCharacter(movement);
    }

    private void ShouldNotCallMoveCharacter()
    {
        var movement = actorComponent.GetMovement();
        unityComponent.DidNotReceive().MoveCharacter(movement);
    }

#endregion
}