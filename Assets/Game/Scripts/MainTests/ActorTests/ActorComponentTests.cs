using Main.ViewComponent;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace MainTests.ActorTests
{
    public class ActorComponentTests
    {
    #region Test Methods

        [Test]
        public void Should_Succeed_When_Call_SetText()
        {
            // arrange
            var gameObject     = new GameObject();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            var textComponent  = gameObject.AddComponent<Text>();
            var displayText    = "fdsjhjkfh";
            actorComponent.text_IdAndDataId = textComponent;
            // act
            actorComponent.SetText(displayText);
            // assert
            Assert.NotNull(actorComponent.text_IdAndDataId);
            Assert.AreEqual(displayText , actorComponent.text_IdAndDataId.text);
        }

        [Test]
        [TestCase(1 , -1)]
        [TestCase(0 , 1)]
        public void Should_Succeed_When_Call_SetDirection(int directionValue , int expectedScaleValue)
        {
            // arrange
            var gameObject        = new GameObject();
            var actorComponent    = gameObject.AddComponent<ActorComponent>();
            var rendererTransform = new GameObject("Renderer").transform;
            actorComponent.Rednerer = rendererTransform;
            // act
            actorComponent.SetDirection(directionValue);
            // assert
            Assert.AreEqual(expectedScaleValue , rendererTransform.localScale.x);
        }

        [Test]
        public void Should_Is_Jumping_True_When_Call_Jump()
        {
            // arrange
            var gameObject     = new GameObject();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            actorComponent.isOnGround = true;
            Assert.AreEqual(true , actorComponent.isOnGround);
            // act
            actorComponent.Jump();
            // assert
            Assert.AreEqual(false , actorComponent.isOnGround);
        }

        [Test]
        public void Should_Is_Attacking_True_When_Call_Attack()
        {
            // arrange
            var gameObject     = new GameObject();
            var unityComponent = Substitute.For<IUnityComponent>();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            actorComponent.UnityComponent = unityComponent;
            Assert.NotNull(actorComponent.UnityComponent);
            Assert.AreEqual(false , actorComponent.isAttacking);
            // act
            actorComponent.Attack();
            // assert
            Assert.AreEqual(true , actorComponent.isAttacking);
        }

        [Test]
        public void Should_Call_PlayAnimation_Attack_When_Call_Attack()
        {
            // arrange
            var gameObject     = new GameObject();
            var unityComponent = Substitute.For<IUnityComponent>();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            actorComponent.UnityComponent = unityComponent;
            Assert.NotNull(actorComponent.UnityComponent);
            // act
            actorComponent.Attack();
            // assert
            unityComponent.Received(1).PlayAnimation("Attack");
        }

    #endregion
    }
}