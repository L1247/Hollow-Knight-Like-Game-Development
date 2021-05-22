using Main.ViewComponent;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace MainTests.ActorTests
{
    public class ActorComponentTests
    {
    #region Private Variables

        private ActorComponent  actorComponent;
        private GameObject      gameObject;
        private IUnityComponent unityComponent;
        private Text            textComponent;
        private Transform       rendererTransform;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void Setup()
        {
            gameObject                      = new GameObject();
            actorComponent                  = gameObject.AddComponent<ActorComponent>();
            textComponent                   = gameObject.AddComponent<Text>();
            actorComponent.text_IdAndDataId = textComponent;
            rendererTransform               = new GameObject("Renderer").transform;
            actorComponent.Rednerer         = rendererTransform;
            unityComponent                  = Substitute.For<IUnityComponent>();
            actorComponent.UnityComponent   = unityComponent;
            Assert.NotNull(actorComponent.UnityComponent);
        }

    #endregion

    #region Test Methods

        [Test]
        public void Should_Succeed_When_Call_SetText()
        {
            // arrange
            var displayText = "fdsjhjkfh";
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
            // act
            actorComponent.SetDirection(directionValue);
            // assert
            Assert.AreEqual(expectedScaleValue , rendererTransform.localScale.x);
        }

        [Test]
        public void Should_Is_Jumping_True_When_Call_Jump()
        {
            // arrange
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
            Assert.AreEqual(false , actorComponent.isAttacking);
            // act
            actorComponent.Attack();
            // assert
            Assert.AreEqual(true , actorComponent.isAttacking);
        }

        [Test]
        public void Should_Call_PlayAnimation_Attack_When_Call_Attack()
        {
            // act
            actorComponent.Attack();
            // assert
            unityComponent.Received(1).PlayAnimation("Attack");
        }

        [Test]
        public void Should_Call_PlayAnimation_Jump_When_Call_Jump()
        {
            // act
            actorComponent.Jump();
            // assert
            unityComponent.Received(1).PlayAnimation("Jump");
        }

    #endregion
    }
}